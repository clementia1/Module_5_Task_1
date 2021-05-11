using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Module_5_Task_1.Dto.Registration;
using Module_5_Task_1.Models;
using Module_5_Task_1.Services.Abstractions;

namespace Module_5_Task_1.Services.Implementations
{
    public class RegistrationService : IRegistrationService
    {
        private readonly string _endpointUrl;
        private readonly IHttpService _httpService;
        private readonly IConfigService _configService;

        public RegistrationService()
        {
            _configService = new ConfigService();
            _httpService = new HttpService();

            var config = _configService.ReadConfig();
            _endpointUrl = config.ApiUrl + config.RegistrationControllerRoute;
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var httpMessage = new HttpRequestMessage(HttpMethod.Post, _endpointUrl);
            httpMessage.Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpService.SendAsync<RegistrationResponse>(httpMessage);

            return response;
        }
    }
}
