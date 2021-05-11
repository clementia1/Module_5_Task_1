using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module_5_Task_1.Services.Abstractions;
using Module_5_Task_1.Services.Implementations;
using Module_5_Task_1.Dto.User;
using Module_5_Task_1.Dto.Authorization;
using Module_5_Task_1.Dto.Registration;

namespace Module_5_Task_1
{
    public class Starter
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IRegistrationService _registrationService;
        private readonly IUserService _userService;
        private readonly IUnknownService _unknownService;

        public Starter()
        {
            _authorizationService = new AuthorizationService();
            _registrationService = new RegistrationService();
            _userService = new UserService();
            _unknownService = new UnknownService();
        }

        public async Task Run()
        {
            var requests = new List<Task>()
            {
                Task.Run(() => _userService.GetByPage(2)),
                Task.Run(() => _userService.GetById(1)),
                Task.Run(() => _userService.GetById(999)),
                Task.Run(() => _unknownService.GetByPage(1)),
                Task.Run(() => _unknownService.GetById(6)),
                Task.Run(() => _unknownService.GetById(666)),
                Task.Run(() => _userService.Add(new CreateUserRequest { Name = "morpheus", Job = "leader" })),
                Task.Run(() => _userService.Update(new UpdateUserRequest { Name = "morpheus", Job = "zion resident" }, 3)),
                Task.Run(() => _userService.Patch(new UpdateUserRequest { Name = "morpheus", Job = "zion resident" }, 3)),
                Task.Run(() => _userService.Delete(1)),
                Task.Run(() => _registrationService.Register(new RegistrationRequest { Email = "eve.holt@reqres.in", Password = "123456" })),
                Task.Run(() => _registrationService.Register(new RegistrationRequest { Email = "eve.holt@reqres.in" })),
                Task.Run(() => _authorizationService.Authorize(new AuthorizationRequest { Email = "eve.holt@reqres.in", Password = "cityslicka" })),
                Task.Run(() => _authorizationService.Authorize(new AuthorizationRequest { Password = "cityslicka" })),
                Task.Run(() => _userService.GetByPageWithDelay(1, 3)),
            };

            await Task.WhenAll(requests);
            Console.WriteLine("All tasks completed");
        }
    }
}
