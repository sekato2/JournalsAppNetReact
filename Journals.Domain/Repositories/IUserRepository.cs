using Journals.Domain.Entities;

namespace Journals.Domain.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAll();
    Task<User?> GetById(int id);
    Task<int> Create(User user);
    Task Suscribe(User subscribed, User subscriberUser);
    Task Unsubscribe(User subscribed, User subscriberUsed);
}
