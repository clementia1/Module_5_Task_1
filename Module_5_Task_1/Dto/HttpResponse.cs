using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Module_5_Task_1.Dto
{
    public class HttpResponse<Type>
    {
        public HttpStatusCode StatusCode { get; set; }

        public Type RootObject { get; set; }
    }
}
