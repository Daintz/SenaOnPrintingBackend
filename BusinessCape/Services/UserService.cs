using DataCape.Models;
using PersistenceCape.Interfaces;

namespace BusinessCape.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserModel>> Index()
        {
            return await _userRepository.Index();
        }

        public async Task<UserModel> Show(long id)
        {
            return await _userRepository.Show(id);
        }

        public async Task Create(UserModel user)
        {
            await _userRepository.Create(user);
        }

        public async Task Update(UserModel user)
        {
            await _userRepository.Update(user);
        }

        public async Task Delete(long id)
        {
            await _userRepository.Delete(id);
        }
    }
}
