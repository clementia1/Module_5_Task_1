using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module_5_Task_1.Dto.Unknown;

namespace Module_5_Task_1.Services.Abstractions
{
    public interface IUnknownService
    {
        Task<UnknownResponse> GetById(int userId);

        Task<IReadOnlyCollection<UnknownDto>> GetByPage(int pageNumber);
    }
}
