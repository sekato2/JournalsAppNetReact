using Journals.Domain.Entities;
using Journals.Domain.Repositories;
using System.Linq;

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

        public async Task Suscribe(int subscribedToId, int subscriberId)
        {
            await ValidateUsersSuscription(subscribedToId, subscriberId, true);
        }

        public async Task Unsubscribe(int subscribedToId, int subscriberId)
        {
            await ValidateUsersSuscription(subscribedToId, subscriberId, false);
        }

        private async Task ValidateUsersSuscription(int subscribedToId, int subscriberId, bool suscribe)
        {
            var suscriberUser = await GetById(subscriberId);
            if (suscriberUser is null) return;
            var suscribed = await GetById(subscribedToId);
            if (suscribed is null) return;

            if (suscribe)
            {
                if (!suscriberUser.Subscriptions.Any(y => y.Id == subscribedToId))
                {
                    await UserRepository.Suscribe(suscribed, suscriberUser);
                }
            }
            else
            {
                if (suscriberUser.Subscriptions.Any(y => y.Id == subscribedToId))
                {
                    await UserRepository.Unsubscribe(suscribed, suscriberUser);
                }
            }
        }
    }
}
