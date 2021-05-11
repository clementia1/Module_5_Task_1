using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module_5_Task_1.Dto.Registration;

namespace Module_5_Task_1.Services.Abstractions
{
    public interface IRegistrationService
    {
        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}
