using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Module_5_Task_1.Dto.User;

namespace Module_5_Task_1.Services.Abstractions
{
    public interface IUserService
    {
        Task<UserDto> GetById(int userId);
        Task<IReadOnlyCollection<UserDto>> GetByPage(int pageNumber);
        Task<IReadOnlyCollection<UserDto>> GetByPageWithDelay(int pageNumber, int delay);
        Task<CreateUserResponse> Add(CreateUserRequest userData);
        Task<UpdateUserResponse> Update(UpdateUserRequest userData, int userId);
        Task<UpdateUserResponse> Patch(UpdateUserRequest userData, int userId);
        Task<HttpStatusCode> Delete(int userId);
    }
}
