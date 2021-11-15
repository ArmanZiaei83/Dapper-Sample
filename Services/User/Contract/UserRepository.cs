using System.Collections.Generic;
using System.Threading.Tasks;
using Services.User.Contract.Dtos;

namespace Services.User.Contract
{
    public interface UserRepository
    {
        public Task<IEnumerable<GetUserDto>> GetAll();
    }
}