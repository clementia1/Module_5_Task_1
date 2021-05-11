using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module_5_Task_1.Services.Abstractions;

namespace Module_5_Task_1.Services.Implementations
{
    public static class LocatorService
    {
        public static IConfigService ConfigService => new ConfigService();
        public static IHttpService HttpService => new HttpService();
        public static IRegistrationService RegistrationService => new RegistrationService();
        public static IAuthorizationService AuthorizationService => new AuthorizationService();
        public static IUnknownService UnknownService => new UnknownService();
    }
}
