using Journals.Domain.Entities;
using Journals.Domain.Repositories;

namespace Journals.Application.Users
{
    internal class UsersService(IUserRepository UserRepository) : IUsersService
    {
        public async Task<int> Create(User user)
        {
            int id = await UserRepository.Create(user);
            return id;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await UserRepository.GetAll();
            return users!;
        }

        public async Task<User?> GetById(int id)
        {
            var users = await UserRepository.GetById(id);
            return users;
        }
    }
}
