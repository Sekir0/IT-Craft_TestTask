using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain
{
    public interface IUsersService
    {
        Task<IEnumerable<Users>> GetAllAsync();

        Task<Users> GetByIdAsync(Guid id);

        Task<(DomainResult, string)> CreateAsync(string name, bool active);

        Task UpdateAsync(Guid id, bool active);

        Task DeleteAsync(Guid id);
    }

    public class UsersService : IUsersService
    {
        public Task<(DomainResult, string)> CreateAsync(string name, bool active)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Users>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Users> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid id, bool active)
        {
            throw new NotImplementedException();
        }
    }
}
