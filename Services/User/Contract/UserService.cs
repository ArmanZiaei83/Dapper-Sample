using System.Collections.Generic;
using System.Threading.Tasks;
using Services.User.Contract.Dtos;

namespace Services.User.Contract
{
    public interface UserService
    {
        public Task<IEnumerable<GetUserDto>> GetAll();
    }
}