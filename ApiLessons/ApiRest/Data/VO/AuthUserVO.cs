using ApiRest.Model.Base;
using System;

namespace ApiRest.Data.VO
{
    public class AuthUserVO : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
