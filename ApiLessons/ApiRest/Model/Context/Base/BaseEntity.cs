﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }
    }
}
