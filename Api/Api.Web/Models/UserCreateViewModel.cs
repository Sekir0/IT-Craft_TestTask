using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Web.Models
{
    public class UserCreateViewModel
    {
        public string Name { get; set; }

        public bool Active { get; set; }
    }
}
