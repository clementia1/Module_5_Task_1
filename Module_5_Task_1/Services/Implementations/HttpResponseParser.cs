using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Module_5_Task_1.Services.Implementations
{
    public class HttpResponseParser
    {
        public async Task<string> ParseResponseDataAsync(HttpResponseMessage responseMessage)
        {
            var content = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(content);
            return jsonObject["data"].ToString();
        }

        public async Task<string> ParseResponseAsync(HttpResponseMessage responseMessage)
        {
            var content = await responseMessage.Content.ReadAsStringAsync();
            return content;
        }
    }
}
