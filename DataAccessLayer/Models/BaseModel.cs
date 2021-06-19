using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace DataAccessLayer.Models
{
    public class BaseModel
    {
        [JsonProperty(PropertyName = "is_active") ]
        public bool isActive { get; set; }
        [JsonProperty(PropertyName = "created_date")]
        public DateTime CreatedDate { get; set; }
        [JsonProperty(PropertyName = "modified_date")]
        public DateTime ModifiedDate { get; set; }
    }
}
