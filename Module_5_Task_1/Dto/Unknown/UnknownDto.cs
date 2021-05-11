using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Module_5_Task_1.Dto.Unknown
{
    [Serializable]
    public class UnknownDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "year", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("")]
        public int Year { get; set; }

        [JsonProperty(PropertyName = "color", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("")]
        public string Color { get; set; }

        [JsonProperty(PropertyName = "pantone_value", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("")]
        public string PantoneValue { get; set; }
    }
}
