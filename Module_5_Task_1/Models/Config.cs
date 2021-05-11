using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_5_Task_1.Models
{
    public class Config
    {
        public string ApiUrl { get; set; }
        public string UserControllerRoute { get; set; }
        public string AuthorizationControllerRoute { get; set; }
        public string RegistrationControllerRoute { get; set; }
        public string UnknownControllerRoute { get; set; }
    }
}
