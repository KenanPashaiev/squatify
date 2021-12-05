using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VideoService.Core;
using VideoService.DAL.Abstractions;
using Xabe.FFmpeg;

namespace VideoService.DAL
{
    public class VideoUploader : IVideoUploader
    {

        private const string VideExtension = "mp4";
        private readonly string VideoDirectory = "/video/";
        private readonly TimeSpan SeparationMargin = new TimeSpan(0, 0, 2); // 2 seconds

        public VideoUploader()
        {
            string subPath = "/video/";
            bool exists = System.IO.Directory.Exists(subPath);
            if (!exists)
                System.IO.Directory.CreateDirectory(subPath);

        }

        public async Task<Stream> GetVideoChunkAsync(Guid videoChunkId)
        {
            var videoChunkPath = GetVideoPath(videoChunkId.ToString());
            var videoStream = File.OpenRead(videoChunkPath);
            return videoStream;
        }

        public async Task<Video> UploadVideoAsync(Stream stream, Video video)
        {
            var fullVideoPath = await UploadFullVideo(stream, video.Id.ToString());
            var fullVideoDuration = (await FFmpeg.GetMediaInfo(fullVideoPath)).Duration;

            var videoChunks = new List<VideoChunk>();
            var timeStamp = TimeSpan.Zero;
            for (int i = 0; timeStamp < fullVideoDuration; ++i)
            {
                var videoChunk = new VideoChunk
                {
                    Id = Guid.NewGuid(),
                    Index = i,
                    StartTime = timeStamp,
                    EndTime = timeStamp + SeparationMargin,
                    VideoId = video.Id
                };

                if(videoChunk.EndTime > fullVideoDuration)
                {
                    videoChunk.EndTime = fullVideoDuration;
                }

                var videoChunkPath = GetVideoPath(videoChunk.Id.ToString());
                var conversion = await FFmpeg.Conversions.FromSnippet.Split(fullVideoPath, videoChunkPath, videoChunk.StartTime, videoChunk.EndTime);
                await conversion.Start();
                videoChunks.Add(videoChunk);
                timeStamp = videoChunks.LastOrDefault()?.EndTime ?? TimeSpan.Zero;
                Console.WriteLine($"{videoChunkPath} ({videoChunk.StartTime} - {videoChunk.EndTime}) video chunk number {i} created");
            }
            File.Delete(fullVideoPath);

            var uploadedVideo = new Video
            {
                Id = video.Id,
                Length = fullVideoDuration,
                CreatedDate = DateTime.UtcNow,
                VideoChunks = videoChunks,
                UserId = video.UserId
            };
            return uploadedVideo;
        }

        public void DeleteVideo(Video video)
        {
            File.Delete(video.Id.ToString());
            foreach (var videoChunk in video.VideoChunks)
            {
                File.Delete(videoChunk.Id.ToString());
            }
        }

        private async Task<string> UploadFullVideo(Stream stream, string videoId)
        {
            var videoPath = GetVideoPath(videoId);
            using (var targetStream = System.IO.File.Open(videoPath, FileMode.OpenOrCreate))
            {
                await stream.CopyToAsync(targetStream);
            }
            Console.WriteLine($"{videoPath} full video created");

            return videoPath;
        }

        private string GetVideoPath(string videoId)
        {
            var fileName = $"{videoId}.{VideExtension}";
            return Path.Combine(VideoDirectory, fileName);
        }
    }
}