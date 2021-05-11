using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Module_5_Task_1.Dto;
using Module_5_Task_1.Services.Abstractions;

namespace Module_5_Task_1.Services.Implementations
{
    public class HttpService : IHttpService
    {
        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.SendAsync(requestMessage);
                return response;
            }
        }

        public async Task<TResponseObject> SendAsync<TResponseObject>(HttpRequestMessage requestMessage)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.SendAsync(requestMessage);
                var content = await response.Content.ReadAsStringAsync();
                var responseObj = JsonConvert.DeserializeObject<TResponseObject>(content);
                return responseObj;
            }
        }
    }
}
