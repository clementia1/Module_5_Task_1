using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Module_5_Task_1.Dto.Unknown;
using Module_5_Task_1.Services.Abstractions;

namespace Module_5_Task_1.Services.Implementations
{
    public class UnknownService : IUnknownService
    {
        private readonly string _endpointUrl;
        private readonly IHttpService _httpService;
        private readonly IConfigService _configService;

        public UnknownService()
        {
            _configService = LocatorService.ConfigService;
            _httpService = LocatorService.HttpService;

            var config = _configService.ReadConfig();
            _endpointUrl = config.ApiUrl + config.UnknownControllerRoute;
        }

        public async Task<UnknownResponse> GetById(int userId)
        {
            var url = @$"{_endpointUrl}/{userId}";
            var httpMessage = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _httpService.SendAsync<UnknownResponse>(httpMessage);

            return response;
        }

        public async Task<IReadOnlyCollection<UnknownDto>> GetByPage(int pageNumber)
        {
            var url = @$"{_endpointUrl}?page={pageNumber}";
            var httpMessage = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _httpService.SendAsync<UnknownPaginationResponse>(httpMessage);

            return response.Users;
        }
    }
}
