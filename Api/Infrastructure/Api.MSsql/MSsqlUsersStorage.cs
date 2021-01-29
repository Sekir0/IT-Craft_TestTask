using Api.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Users> GetUserByIdAsync(Guid id)
        {
            var entity = await context.UsersEntities.SingleOrDefaultAsync(x => x.UserId == id);
            return entity == null ? null : ToDomain(entity);
        }

        public async Task<IEnumerable<Users>> FindManyAsync()
        {
            var entities = await context.UsersEntities.ToListAsync();
            return entities.Select(ToDomain).ToList();
        }

        public async Task<Guid> InsertAsync(Users users)
        {
            var entity = new UsersEntity
            {
                UserId = users.Id,
                Name = users.Name,
                Active = users.Active
            };

            await context.AddAsync(entity);
            await context.SaveChangesAsync();

            return entity.UserId;
        }

        public async Task UpdateAsync(Guid id, Users updatedUsers)
        {
            var entity = await context.UsersEntities.SingleOrDefaultAsync(x => x.UserId == updatedUsers.Id);

            entity.Active = updatedUsers.Active;

            context.UsersEntities.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await context.UsersEntities.SingleOrDefaultAsync(x => x.UserId == id);
            context.UsersEntities.Remove(entity);
            await context.SaveChangesAsync();
        }

        private static Users ToDomain(UsersEntity entity)
        {
            return new Users(
                entity.UserId,
                entity.Name,
                entity.Active);
        }
    }
}
