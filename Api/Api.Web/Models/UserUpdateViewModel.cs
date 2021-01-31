using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Web.Models
{
    public class UserUpdateViewModel
    {
        [Required]
        public bool Active { get; set; }
    }
}
