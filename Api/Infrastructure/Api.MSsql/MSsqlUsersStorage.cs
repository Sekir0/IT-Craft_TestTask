using Api.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.MSsql
{
    public class MSsqlUsersStorage : IUsersStorage
    {
        private readonly MSsqlContext context;

        public MSsqlUsersStorage(MSsqlContext context)
        {
            this.context = context;
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<(IEnumerable<Users>, long)> FindManyAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<Users> GetUserByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> InsertAsync(Users users)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid id, Users updatedUsers)
        {
            throw new NotImplementedException();
        }
    }
}
