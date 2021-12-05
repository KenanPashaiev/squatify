using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using VideoService.API.Services.Abstractions;
using VideoService.BL.Abstractions;
using VideoService.BL.Models;
using VideoService.BL.Utilities;

namespace VideoService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoController : ControllerBase
    {
        private const int FileSizeLimit = 1048576 * 100;
        private const string PermittedExtension = ".mp4";

        private readonly FormOptions defaultFormOptions;

        private readonly IVideoManager videoManager;
        private readonly IUserService userService;

        public VideoController(IUserService userService, IVideoManager videoManager)
        {
            string workingDirectory = Directory.GetCurrentDirectory();

            this.userService = userService;
            this.videoManager = videoManager;
            defaultFormOptions = new FormOptions();
            defaultFormOptions.MemoryBufferThreshold = FileSizeLimit;
            this.userService = userService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetVideosByUserIdAsync(Guid id)
        {
            var videos = await videoManager.GetVideosByUserIdAsync(id);
            return Ok(videos);
        }

        [Authorize(Roles = "Client, Admin")]
        [HttpGet("{videoId}/clip/{videoChunkId}")]
        public async Task<IActionResult> GetVideoClipAsync(Guid videoId, Guid videoChunkId)
        {
            var role = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
            var currentUserId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            var video = await videoManager.GetVideoAsync(videoId);
            if(currentUserId?.Value != video?.UserId.ToString())
            {
                return Unauthorized();
            }

            var stream = await videoManager.GetVideoChunkAsync(videoChunkId);
            return File(stream, "multipart/form-data");
        }

        [Authorize(Roles = "Client, Admin")]
        [HttpGet("map")]
        public async Task<IActionResult> GetVideoMapAsync(Guid videoId, TimeSpan time)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            var user = await userService.GetUserAsync(userId);
            var video = await videoManager.GetVideoAsync(videoId);
            if(user?.Id != video?.UserId)
            {
                return Unauthorized();
            }

            Console.WriteLine(time.ToString());
            var videoMap = videoManager.GetVideoMap(video, time);

            return Ok(videoMap);
        }

        [Authorize(Roles = "Client, Admin")]
        [HttpPost("upload")]
        public async Task<IActionResult> UploadVideoAsync()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            var user = await userService.GetUserAsync(userId);
            if(user?.Id == null)
            {
                //TODO: Log error
                return Unauthorized();
            }

            var boundary = MultipartRequestHelper.GetBoundary(
                MediaTypeHeaderValue.Parse(Request.ContentType),
                defaultFormOptions.MultipartBoundaryLengthLimit);
            if (!MultipartRequestHelper.IsMultipartContentType(Request.ContentType))
            {
                //TODO: Log error
                return BadRequest();
            }

            var reader = new MultipartReader(boundary, HttpContext.Request.Body);
            var createdVideoId = await videoManager.UploadVideoAsync(reader, user.Id);
            if(createdVideoId == null)
            {
                //TODO: Log error
                return BadRequest();
            }

            return Created(nameof(VideoController), createdVideoId);
        }
    }
}
