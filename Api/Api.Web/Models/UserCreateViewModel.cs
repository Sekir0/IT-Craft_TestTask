using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Web.Models
{
    public class UserCreateViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
