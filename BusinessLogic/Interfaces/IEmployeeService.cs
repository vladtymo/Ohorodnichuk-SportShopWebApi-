using BusinessLogic.ApiModels;
using BusinessLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAsync();
        Task<EmployeeDto?> GetAsync(int id);
        Task CreateAsync(CreateEmployeeModel model);
        Task EditAsync(EditEmployeeModel model);
        Task DeleteAsync(int id);
    }
}
