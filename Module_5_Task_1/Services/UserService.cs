using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Module_5_Task_1.Dto;

namespace Module_5_Task_1.Services
{
    public class UserService
    {
        private readonly string _endpointUrl;
        private readonly HttpService _httpService;
        private readonly ConfigService _configService;

        public UserService()
        {
            _configService = new ConfigService();
            _httpService = new HttpService();

            var apiRoute = _configService.ReadConfig().ApiUrl;
            var userControllerRoute = _configService.ReadConfig().UserControllerRoute;
            _endpointUrl = apiRoute + userControllerRoute;
        }

        public async Task<UserResponse> GetById(int userId)
        {
            var url = @$"{_endpointUrl}/{userId}";
            var httpMessage = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpService.SendAsync(httpMessage);
            var data = await _httpService.ParseResponseAsync(response);
            var user = JsonConvert.DeserializeObject<UserResponse>(data);

            return user;
        }

        public async Task<IReadOnlyCollection<UserResponse>> GetByPage(int pageNumber)
        {
            var url = @$"{_endpointUrl}?page={pageNumber}";
            var httpMessage = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpService.SendAsync(httpMessage);
            var data = await _httpService.ParseResponseAsync(response);
            var users = JsonConvert.DeserializeObject<IReadOnlyCollection<UserResponse>>(data);

            return users;
        }

        public async Task<CreateUserResponse> Add(CreateUserRequest userData)
        {
            var httpMessage = new HttpRequestMessage(HttpMethod.Post, _endpointUrl);
            httpMessage.Content = new StringContent(JsonConvert.SerializeObject(userData), Encoding.UTF8, "application/json");

            var response = await _httpService.SendAsync(httpMessage);
            var data = await _httpService.ParseResponseAsync(response);
            var createdUser = JsonConvert.DeserializeObject<CreateUserResponse>(data);

            return createdUser;
        }

        public async Task<UpdateUserResponse> Update(UpdateUserRequest userData, int userId)
        {
            var url = @$"{_endpointUrl}/{userId}";
            var httpMessage = new HttpRequestMessage(HttpMethod.Put, url);
            httpMessage.Content = new StringContent(JsonConvert.SerializeObject(userData), Encoding.UTF8, "application/json");

            var response = await _httpService.SendAsync(httpMessage);
            var data = await _httpService.ParseResponseAsync(response);
            var updatedUser = JsonConvert.DeserializeObject<UpdateUserResponse>(data);

            return updatedUser;
        }

        public async Task<UpdateUserResponse> Patch(UpdateUserRequest userData, int userId)
        {
            var url = @$"{_endpointUrl}/{userId}";
            var httpMessage = new HttpRequestMessage(HttpMethod.Patch, url);
            httpMessage.Content = new StringContent(JsonConvert.SerializeObject(userData), Encoding.UTF8, "application/json");

            var response = await _httpService.SendAsync(httpMessage);
            var data = await _httpService.ParseResponseAsync(response);
            var updatedUser = JsonConvert.DeserializeObject<UpdateUserResponse>(data);

            return updatedUser;
        }

        public async Task<HttpStatusCode> Delete(int userId)
        {
            var url = @$"{_endpointUrl}/{userId}";
            var httpMessage = new HttpRequestMessage(HttpMethod.Delete, url);
            var response = await _httpService.SendAsync(httpMessage);

            return response.StatusCode;
        }
    }
}
