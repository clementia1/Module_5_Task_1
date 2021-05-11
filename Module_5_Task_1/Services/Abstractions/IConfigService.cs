using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module_5_Task_1.Models;

namespace Module_5_Task_1.Services.Abstractions
{
    public interface IConfigService
    {
        Config ReadConfig();
    }
}
