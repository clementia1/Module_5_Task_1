using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Module_5_Task_1.Models;
using Module_5_Task_1.Dto.Unknown;

namespace Module_5_Task_1.Services.Implementations
{
    public class UnknownService
    {
        private readonly string _endpointUrl;
        private readonly Config _config;
        private readonly HttpService _httpService;
        private readonly HttpResponseParser _httpResponseParser;
        private readonly ConfigService _configService;

        public UnknownService()
        {
            _configService = new ConfigService();
            _httpService = new HttpService();
            _httpResponseParser = new HttpResponseParser();

            _config = _configService.ReadConfig();
            _endpointUrl = _config.ApiUrl + _config.UnknownControllerRoute;
        }

        public async Task<UnknownResponse> GetById(int userId)
        {
            var url = @$"{_endpointUrl}/{userId}";
            var httpMessage = new HttpRequestMessage(HttpMethod.Get, url);

            var data = await _httpService.SendAsync<UnknownResponse>(httpMessage);

            return data;
        }

        public async Task<IReadOnlyCollection<UnknownDto>> GetByPage(int pageNumber)
        {
            var url = @$"{_endpointUrl}?page={pageNumber}";
            var httpMessage = new HttpRequestMessage(HttpMethod.Get, url);

            var httpResponse = await _httpService.SendAsync(httpMessage);
            var content = await _httpResponseParser.ParseResponseAsync(httpResponse);
            var paginationData = JsonConvert.DeserializeObject<UnknownPaginationResponse>(content);

            return paginationData.Users;
        }
    }
}
