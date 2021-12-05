using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using VideoService.BL.Abstractions;
using VideoService.BL.Utilities;
using VideoService.Core;
using VideoService.DAL.Abstractions;

namespace VideoService.BL.Managers
{
    public class VideoManager : IVideoManager
    {
        private const int PreviousChunkCount = 2;
        private const int NextChunkCount = 5;

        public readonly IVideoUploader videoUploader;
        public readonly IVideoRepository videoRepository;

        public VideoManager(IVideoUploader videoUploader, IVideoRepository videoRepository)
        {
            this.videoUploader = videoUploader;
            this.videoRepository = videoRepository;
        }

        public async Task<Video> GetVideoAsync(Guid videoId)
        {
            return await videoRepository.GetAsync(videoId);
        }

        public async Task<IEnumerable<Video>> GetVideosByUserIdAsync(Guid userId)
        {
            return await videoRepository.GetByUserIdAsync(userId);
        }

        public Task<Stream> GetVideoChunkAsync(Guid videoChunkId)
        {
            return videoUploader.GetVideoChunkAsync(videoChunkId);
        }

        public IEnumerable<VideoChunk> GetVideoMap(Video video, TimeSpan time)
        {
            var selectedChunk = video.VideoChunks
                .SingleOrDefault(vc => vc.StartTime <= time && time <= vc.EndTime);
            if(selectedChunk == null)
            {
                return null;
            }

            var lastPreviousChunkIndex = selectedChunk.Index - PreviousChunkCount;
            var lastNextChunkIndex = selectedChunk.Index + NextChunkCount;
            var chunkMap = video.VideoChunks
                .Where(vc => lastPreviousChunkIndex <= vc.Index && vc.Index <= lastNextChunkIndex);

            return chunkMap;
        }

        public async Task<Guid?> UploadVideoAsync(MultipartReader reader, Guid userId)
        {
            var section = await reader.ReadNextSectionAsync();

            var hasContentDispositionHeader =
                ContentDispositionHeaderValue.TryParse(
                    section.ContentDisposition, out var contentDisposition);

            if (!hasContentDispositionHeader)
            {
                return null;
            }

            if (!MultipartRequestHelper.HasFileContentDisposition(contentDisposition))
            {
                //TODO: Log error
                return null;
            }

            var videoToUpload = new Video()
            {
                Id = Guid.NewGuid(),
                UserId = userId
            };

            var uploadedVideo = await videoUploader.UploadVideoAsync(section.Body, videoToUpload);
            await videoRepository.AddAsync(uploadedVideo);

            return uploadedVideo.Id;
        }

        public async Task<Guid?> DeleteVideoAsync(Guid videoId, Guid userId)
        {
            var video = await videoRepository.GetAsync(videoId);
            if(video.UserId != userId)
            {
                return null;
            }

            videoUploader.DeleteVideo(video);
            return video.Id;
        }
    }
}
