using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Module_5_Task_1.Services.Abstractions
{
    public interface IHttpService
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage);

        Task<TResponseObject> SendAsync<TResponseObject>(HttpRequestMessage requestMessage);
    }
}
