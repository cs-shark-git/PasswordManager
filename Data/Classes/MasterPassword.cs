using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace PasswordManager.Data.Classes
{
    class MasterPassword
    {
        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("length")]
        public int Length { get; set; }

        [JsonProperty("safe")]
        public bool Safe { get; set; }
    }
}