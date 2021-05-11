using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace Module_5_Task_1.Dto
{
    public interface IHttpResponse
    {
        HttpStatusCode StatusCode { get; set; }
    }
}
