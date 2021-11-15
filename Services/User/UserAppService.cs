using System.Collections.Generic;
using System.Threading.Tasks;
using Services.User.Contract;
using Services.User.Contract.Dtos;

namespace Services.User
{
    public class UserAppService : UserService
    {
        private readonly UserRepository _repository;

        public UserAppService(UserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GetUserDto>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}