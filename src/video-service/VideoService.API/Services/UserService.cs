using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using VideoService.API.Services.Abstractions;
using VideoService.API.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication;

namespace VideoService.API.Services
{
    public class UserService : IUserService
    {
        private readonly string controllerUrl = "User";
        private readonly string serviceUrl;

        private readonly HttpClient httpClient;
        private readonly IHttpContextAccessor accessor;

        public UserService(HttpClient httpClient, IConfiguration config, IHttpContextAccessor accessor)
        {
            this.serviceUrl = config["USERSERVICE_ADDRESS"];
            this.httpClient = httpClient;
            this.accessor = accessor;
        }

        public async Task<UserDto> GetUserAsync(string id)
        {
            var requestUri = $"http://{serviceUrl}/{controllerUrl}/{id}";

            var token = await accessor.HttpContext.GetTokenAsync("access_token");
            Console.WriteLine(token);
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var response = string.Empty;
            try
            {
                response = await httpClient.GetStringAsync(requestUri);
            }
            catch(Exception ex)
            {
                //TODO: log exception
                Console.WriteLine(ex.Message);
                return null;
            }

            var user = JsonConvert.DeserializeObject<UserDto>(response);
            return user;
        }
    }
}