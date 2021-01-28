using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain
{
    public class UsersContext
    {
        public UsersContext(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
