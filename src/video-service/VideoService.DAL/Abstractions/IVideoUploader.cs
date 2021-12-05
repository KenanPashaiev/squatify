using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using VideoService.Core;

namespace VideoService.DAL.Abstractions
{
    public interface IVideoUploader
    {
        Task<Stream> GetVideoChunkAsync(Guid videoChunkId);
        Task<Video> UploadVideoAsync(Stream stream, Video video);
        void DeleteVideo(Video video);
    }
}