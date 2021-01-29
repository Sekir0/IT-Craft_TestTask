using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.MSsql
{
    public class UsersEntity
    {
        [Key]
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }
    }
}
