using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Module_5_Task_1.Dto.User
{
    public class UserPaginationResponse
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        [JsonProperty("total")]
        public int TotalUserCount { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPageCount { get; set; }

        [JsonProperty("data")]
        public IReadOnlyCollection<UserDto> Users { get; set; }

        [JsonProperty("support")]
        public IReadOnlyDictionary<string, string> Support { get; set; }
    }
}
