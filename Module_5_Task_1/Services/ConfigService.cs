using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Module_5_Task_1.Models;

namespace Module_5_Task_1.Services
{
    public class ConfigService
    {
        private string _configPath;

        public ConfigService()
        {
            _configPath = "config.json";
        }

        public Config ReadConfig()
        {
            var configContent = File.ReadAllText(_configPath);
            var config = JsonConvert.DeserializeObject<Config>(configContent);
            return config;
        }
    }
}
