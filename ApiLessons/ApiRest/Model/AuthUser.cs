using ApiRest.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest.Model
{
   [Table("users")]
    public class AuthUser : BaseEntity
    {
        [Column("user_name")]
        public string UserName { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("full_name")]
        public string FullName { get; set; }

        [Column("refreshed_token")]
        public string RefreshedToken { get; set; }

        [Column("refreshed_token_expire_time")]
        public DateTime RefreshedTokenExpireTime { get; set; }


    }
}
