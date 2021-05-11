using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Module_5_Task_1.Models;
using Module_5_Task_1.Dto.User;

namespace Module_5_Task_1.Services.Implementations
{
    public class UserService
    {
        private readonly string _endpointUrl;
        private readonly Config _config;
        private readonly HttpService _httpService;
        private readonly HttpResponseParser _httpResponseParser;
        private readonly ConfigService _configService;

        public UserService()
        {
            _configService = new ConfigService();
            _httpService = new HttpService();
            _httpResponseParser = new HttpResponseParser();

            _config = _configService.ReadConfig();
            _endpointUrl = _config.ApiUrl + _config.UserControllerRoute;
        }

        public async Task<UserDto> GetById(int userId)
        {
            var url = @$"{_endpointUrl}/{userId}";
            var httpMessage = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _httpService.SendAsync2<UserResponse>(httpMessage);

            return response.RootObject.User;
        }

        public async Task<IReadOnlyCollection<UserDto>> GetByPage(int pageNumber)
        {
            var url = @$"{_endpointUrl}?page={pageNumber}";
            var httpMessage = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _httpService.SendAsync2<UserPaginationResponse>(httpMessage);

            return response.RootObject.Users;
        }

        public async Task<IReadOnlyCollection<UserDto>> GetByPageWithDelay(int pageNumber, int delay)
        {
            var url = @$"{_endpointUrl}?page={pageNumber}&delay={delay}";
            var httpMessage = new HttpRequestMessage(HttpMethod.Get, url);

            var httpResponse = await _httpService.SendAsync(httpMessage);
            var content = await _httpResponseParser.ParseResponseAsync(httpResponse);
            var paginationData = JsonConvert.DeserializeObject<UserPaginationResponse>(content);

            return paginationData.Users;
        }

        public async Task<CreateUserResponse> Add(CreateUserRequest userData)
        {
            var httpMessage = new HttpRequestMessage(HttpMethod.Post, _endpointUrl);
            httpMessage.Content = new StringContent(JsonConvert.SerializeObject(userData), Encoding.UTF8, "application/json");

            var httpResponse = await _httpService.SendAsync(httpMessage);
            var data = await _httpResponseParser.ParseResponseAsync(httpResponse);
            var createdUser = JsonConvert.DeserializeObject<CreateUserResponse>(data);

            return createdUser;
        }

        public async Task<UpdateUserResponse> Update(UpdateUserRequest userData, int userId)
        {
            var url = @$"{_endpointUrl}/{userId}";
            var httpMessage = new HttpRequestMessage(HttpMethod.Put, url);
            httpMessage.Content = new StringContent(JsonConvert.SerializeObject(userData), Encoding.UTF8, "application/json");

            var httpResponse = await _httpService.SendAsync(httpMessage);
            var data = await _httpResponseParser.ParseResponseAsync(httpResponse);
            var updatedUser = JsonConvert.DeserializeObject<UpdateUserResponse>(data);

            return updatedUser;
        }

        public async Task<UpdateUserResponse> Patch(UpdateUserRequest userData, int userId)
        {
            var url = @$"{_endpointUrl}/{userId}";
            var httpMessage = new HttpRequestMessage(HttpMethod.Patch, url);
            httpMessage.Content = new StringContent(JsonConvert.SerializeObject(userData), Encoding.UTF8, "application/json");

            var httpResponse = await _httpService.SendAsync(httpMessage);
            var data = await _httpResponseParser.ParseResponseAsync(httpResponse);
            var updatedUser = JsonConvert.DeserializeObject<UpdateUserResponse>(data);

            return updatedUser;
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
