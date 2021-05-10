using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Module_5_Task_1.Services
{
    public class HttpService
    {
        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.SendAsync(requestMessage);
                return response;
            }
        }

        public async Task<string> ParseResponseAsync(HttpResponseMessage responseMessage)
        {
            var content = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(content);

            if (jsonObject["data"] is not null)
            {
                return jsonObject["data"].ToString();
            }
            else
            {
                return content;
            }
        }
    }
}
