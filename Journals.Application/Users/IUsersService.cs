using Journals.Domain.Entities;

namespace Journals.Application.Users;

public interface IUsersService
{
    Task<IEnumerable<User>> GetAll();
    Task<User?> GetById(int id);
    Task<int> Create(User user);
    Task Suscribe(int subscribedToId, int subscriberId);
    Task Unsubscribe(int subscribedToId, int subscriberId);
}
