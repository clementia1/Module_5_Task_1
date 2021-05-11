using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Module_5_Task_1.Dto.User;
using Module_5_Task_1.Services.Abstractions;

namespace Module_5_Task_1.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly string _endpointUrl;
        private readonly IHttpService _httpService;
        private readonly IConfigService _configService;

        public UserService()
        {
            _configService = new ConfigService();
            _httpService = new HttpService();

            var config = _configService.ReadConfig();
            _endpointUrl = config.ApiUrl + config.UserControllerRoute;
        }

        public async Task<UserDto> GetById(int userId)
        {
            var url = @$"{_endpointUrl}/{userId}";
            var httpMessage = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _httpService.SendAsync<UserResponse>(httpMessage);

            return response.User;
        }

        public async Task<IReadOnlyCollection<UserDto>> GetByPage(int pageNumber)
        {
            var url = @$"{_endpointUrl}?page={pageNumber}";
            var httpMessage = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _httpService.SendAsync<UserPaginationResponse>(httpMessage);

            return response.Users;
        }

        public async Task<IReadOnlyCollection<UserDto>> GetByPageWithDelay(int pageNumber, int delay)
        {
            var url = @$"{_endpointUrl}?page={pageNumber}&delay={delay}";
            var httpMessage = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _httpService.SendAsync<UserPaginationResponse>(httpMessage);

            return response.Users;
        }

        public async Task<CreateUserResponse> Add(CreateUserRequest userData)
        {
            var httpMessage = new HttpRequestMessage(HttpMethod.Post, _endpointUrl);
            httpMessage.Content = new StringContent(JsonConvert.SerializeObject(userData), Encoding.UTF8, "application/json");
            var response = await _httpService.SendAsync<CreateUserResponse>(httpMessage);

            return response;
        }

        public async Task<UpdateUserResponse> Update(UpdateUserRequest userData, int userId)
        {
            var url = @$"{_endpointUrl}/{userId}";
            var httpMessage = new HttpRequestMessage(HttpMethod.Put, url);
            httpMessage.Content = new StringContent(JsonConvert.SerializeObject(userData), Encoding.UTF8, "application/json");
            var response = await _httpService.SendAsync<UpdateUserResponse>(httpMessage);

            return response;
        }

        public async Task<UpdateUserResponse> Patch(UpdateUserRequest userData, int userId)
        {
            var url = @$"{_endpointUrl}/{userId}";
            var httpMessage = new HttpRequestMessage(HttpMethod.Patch, url);
            httpMessage.Content = new StringContent(JsonConvert.SerializeObject(userData), Encoding.UTF8, "application/json");
            var response = await _httpService.SendAsync<UpdateUserResponse>(httpMessage);

            return response;
        }

        public async Task<HttpStatusCode> Delete(int userId)
        {
            var url = @$"{_endpointUrl}/{userId}";
            var httpMessage = new HttpRequestMessage(HttpMethod.Delete, url);
            var httpResponse = await _httpService.SendAsync(httpMessage);

            return httpResponse.StatusCode;
        }
    }
}
