using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module_5_Task_1.Services.Implementations;
using Module_5_Task_1.Dto;

namespace Module_5_Task_1
{
    public class Starter
    {
        private readonly AuthorizationService _authorizationService;
        private readonly RegistrationService _registrationService;
        private readonly UserService _userService;
        private readonly UnknownService _unknownService;

        public Starter()
        {
            _authorizationService = new AuthorizationService();
            _registrationService = new RegistrationService();
            _userService = new UserService();
            _unknownService = new UnknownService();
        }

        public async Task Run()
        {
            // var regRequest = new RegistrationRequest { Email = "eve.holt@reqres.in", Password = "pistol" };
            // var response = await _registrationService.Register(regRequest);
            var res = await _unknownService.GetById(23);
            if (res.Unknown is null)
            {
                Console.WriteLine($"{res}");
            }
            else
            {
                Console.WriteLine($"{res?.Unknown?.Name}");
            }
        }
    }
}
