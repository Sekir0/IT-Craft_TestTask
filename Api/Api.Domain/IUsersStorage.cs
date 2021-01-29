using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Domain
{
    public interface IUsersStorage
    {
        Task<IEnumerable<Users>> FindManyAsync();

        Task<Users> GetByIdAsync(Guid id);

        Task<Guid> InsertAsync(Users users);

        Task<Users> UpdateAsync(Guid id, Users updatedUsers);

        Task DeleteAsync(Guid id);
    }
}
