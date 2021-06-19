using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;
namespace DataAccessLayer.Models
{
    public class UserRoles
    {
        [JsonProperty (PropertyName = "role_id")]
        [Key]
        public int RoleId { get; set; }
        [JsonProperty (PropertyName = "role_name")]
        public string RoleName { get; set; }
        [JsonProperty (PropertyName = "is_active")]
        public bool IsActive { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
