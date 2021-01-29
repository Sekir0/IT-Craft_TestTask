using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain
{
    public class Users
    {
        public Users(Guid id, string name, bool active)
        {
            Id = id;
            Name = name;
            Active = active;
        }

        public Guid Id { get; }
        public string Name { get; private set; }
        public bool Active { get; private set; }


        public void Update(bool active)
        {
            Active = active;
        }
    }
}
