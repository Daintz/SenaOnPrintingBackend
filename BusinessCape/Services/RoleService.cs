using DataCape.Models;
using PersistenceCape.Interfaces;

namespace BusinessCape.Services
{
    public class RoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<Role>> Index()
        {
            return await _roleRepository.Index();
        }

        public async Task<Role> Show(long id)
        {
            return await _roleRepository.Show(id);
        }

        public async Task Create(Role role)
        {
            await _roleRepository.Create(role);
        }

        public async Task Update(Role role)
        {
            await _roleRepository.Update(role);
        }

        public async Task Delete(long id)
        {
            await _roleRepository.Delete(id);
        }
    }
}
