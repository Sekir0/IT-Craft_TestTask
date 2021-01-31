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

        Task<(DomainResult, Guid)> CreateAsync(string name);

        Task<Users> UpdateAsync(Guid id, bool active);

        Task DeleteAsync(Guid id);
    }

    public class UsersService : IUsersService
    {
        private readonly IUsersStorage usersStorage;
        private readonly IValidator<UsersContext> usersValidator;

        public UsersService(
            IUsersStorage usersStorage,
            IValidator<UsersContext> usersValidator)
        {
            this.usersStorage = usersStorage;
            this.usersValidator = usersValidator;
        }

        public async Task<IEnumerable<Users>> GetAllAsync()
        {
            return await usersStorage.FindManyAsync();
        }

        public async Task<Users> GetByIdAsync(Guid id)
        {
            var result = await usersStorage.GetByIdAsync(id);

            return result;
        }

        public async Task<(DomainResult, Guid)> CreateAsync(string name)
        {
            var result = usersValidator.Validate(new UsersContext(name));
            if (!result.Successed)
            {
                return (result, default);
            }

            var user = new Users(Guid.NewGuid(), name, false);

            var userId = await usersStorage.InsertAsync(user);

            return (DomainResult.Success(), userId);
        }

        public async Task<Users> UpdateAsync(Guid id, bool active)
        {
            var user = await usersStorage.GetByIdAsync(id);

            if (user == null)
            {
                return null;
            }

            user.Update(active);

            return await usersStorage.UpdateAsync(id, user);
        }

        public async Task DeleteAsync(Guid id)
        {
            await usersStorage.DeleteAsync(id);
        }
    }
}
