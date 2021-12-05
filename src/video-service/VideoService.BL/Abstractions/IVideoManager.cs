using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using VideoService.Core;

namespace VideoService.BL.Abstractions
{
    public interface IVideoManager
    {
        Task<Video> GetVideoAsync(Guid videoId);
        Task<IEnumerable<Video>> GetVideosByUserIdAsync(Guid userId);
        Task<Stream> GetVideoChunkAsync(Guid videoChunkId);
        IEnumerable<VideoChunk> GetVideoMap(Video video, TimeSpan time);
        Task<Guid?> UploadVideoAsync(MultipartReader reader, Guid userId);
        Task<Guid?> DeleteVideoAsync(Guid videoId, Guid userId);
    }
}
