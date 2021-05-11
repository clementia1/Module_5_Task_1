using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Module_5_Task_1.Dto;
using Module_5_Task_1.Models;

namespace Module_5_Task_1.Services.Implementations
{
    public class RegistrationService
    {
        private readonly string _endpointUrl;
        private readonly Config _config;
        private readonly HttpService _httpService;
        private readonly HttpResponseParser _httpResponseParser;
        private readonly ConfigService _configService;

        public RegistrationService()
        {
            _configService = new ConfigService();
            _httpService = new HttpService();
            _httpResponseParser = new HttpResponseParser();

            _config = _configService.ReadConfig();
            _endpointUrl = _config.ApiUrl + _config.RegistrationControllerRoute;
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var httpMessage = new HttpRequestMessage(HttpMethod.Post, _endpointUrl);
            httpMessage.Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response = await _httpService.SendAsync(httpMessage);
            var data = await _httpResponseParser.ParseResponseAsync(response);
            var registrationResponse = JsonConvert.DeserializeObject<RegistrationResponse>(data);
            return registrationResponse;
        }
    }
}
