using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Module_5_Task_1.Dto;
using Module_5_Task_1.Models;

namespace Module_5_Task_1.Services.Implementations
{
    public class AuthorizationService
    {
        private readonly string _endpointUrl;
        private readonly Config _config;
        private readonly HttpService _httpService;
        private readonly ConfigService _configService;

        public AuthorizationService()
        {
            _configService = new ConfigService();
            _httpService = new HttpService();

            _config = _configService.ReadConfig();
            _endpointUrl = _config.ApiUrl + _config.AuthorizationControllerRoute;
        }

        public void Authorize()
        {
        }
    }
}
