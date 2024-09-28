using Journals.Domain.Entities;
using Journals.Domain.Repositories;
using Journals.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (user != null)
        {
            user.Subscribers = await dbContext.Users.Where(y => y.Subscribers.Contains(user)).ToListAsync();
            user.Subscriptions = await dbContext.Users.Where(y => y.Subscriptions.Contains(user)).ToListAsync();
        }
        return user;
    }

    public async Task Suscribe(User subscribed, User subscriberUser)
    {
        subscribed.Subscribers = new List<User>();
        subscribed.Subscriptions = new List<User>();
        subscriberUser.Subscribers.Add(subscribed);
        await dbContext.SaveChangesAsync();
    }

    public async Task Unsubscribe(User subscribed, User subscriberUser)
    {
        var query = "DELETE FROM UserUser WHERE SubscribersId = @p0 AND SubscriptionsId = @p1";
        await dbContext.Database.ExecuteSqlRawAsync(query, subscribed.Id, subscriberUser.Id);
    }
}
