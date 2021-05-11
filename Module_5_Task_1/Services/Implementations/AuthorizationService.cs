using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Module_5_Task_1.Dto.Authorization;
using Module_5_Task_1.Models;
using Module_5_Task_1.Services.Abstractions;

namespace Module_5_Task_1.Services.Implementations
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly string _endpointUrl;
        private readonly IHttpService _httpService;
        private readonly IConfigService _configService;

        public AuthorizationService()
        {
            _configService = LocatorService.ConfigService;
            _httpService = LocatorService.HttpService;

            var config = _configService.ReadConfig();
            _endpointUrl = config.ApiUrl + config.AuthorizationControllerRoute;
        }

        public async Task<AuthorizationResponse> Authorize(AuthorizationRequest request)
        {
            var httpMessage = new HttpRequestMessage(HttpMethod.Post, _endpointUrl);
            httpMessage.Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpService.SendAsync<AuthorizationResponse>(httpMessage);

            return response;
        }
    }
}
