using Journals.Domain.Entities;
using Journals.Domain.Repositories;
using Journals.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Journals.Infraestructure.Repositories;

internal class UserRepository(JournalDbContext dbContext) : IUserRepository
{
    public async Task<int> Create(User user)
    {
        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();
        return user.Id;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        var users = await dbContext.Users.ToListAsync();
        return users;
    }

    public async Task<User?> GetById(int id)
    {
        var user = await dbContext.Users    
            .Include(y => y.Journals)
            .FirstOrDefaultAsync(x => x.Id == id);
        return user;
    }
}
