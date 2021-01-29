using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain
{
    public interface IUsersStorage
    {
        Task<IEnumerable<Users>> FindManyAsync();

        Task<Users> GetUserByIdAsync(Guid id);

        Task<Guid> InsertAsync(Users users);

        Task UpdateAsync(Guid id, Users updatedUsers);

        Task DeleteAsync(Guid id);
    }
}
