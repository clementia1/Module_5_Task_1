using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module_5_Task_1.Services;
using Module_5_Task_1.Dto;

namespace Module_5_Task_1
{
    public class Starter
    {
        private readonly AuthorizationService _authorizationService;
        private readonly RegistrationService _registrationService;

        public Starter()
        {
            _authorizationService = new AuthorizationService();
            _registrationService = new RegistrationService();
        }

        public async Task Run()
        {
            //var regRequest = new RegistrationRequest { Email = "eve.holt@reqres.in", Password = "pistol" };
            //var response = await _registrationService.Register(regRequest);
            Console.WriteLine($@"{response.Token}, {response.Error}");
        }
    }
}
