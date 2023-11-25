using BusinessLogic.ApiModels;
using BusinessLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IClientService
    {
        Task<List<ClientDto>> GetAsync();
        Task<ClientDto?> GetAsync(int id);
        Task CreateAsync(CreateClientModel model);
        Task EditAsync(EditClientModel model);
        Task DeleteAsync(int id);
    }
}
