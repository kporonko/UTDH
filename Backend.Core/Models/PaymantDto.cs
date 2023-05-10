using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Backend.Core.Models
{
    public class PaymantDto
    {
        [JsonPropertyName("data")]
        public string Data { get; set; }

        [JsonPropertyName("signature")]
        public string Signature { get; set; }
    }
}
