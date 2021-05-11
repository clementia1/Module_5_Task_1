using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_5_Task_1.Dto.User
{
    public class CreateUserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public string CreatedAt { get; set; }
    }
}
