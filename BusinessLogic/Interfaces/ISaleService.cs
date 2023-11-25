using BusinessLogic.ApiModels;
using BusinessLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ISaleService
    {
        Task <List<SaleDto>> GetAsync();
        Task <SaleDto?> GetAsync(int id);
        Task CreateAsync(CreateSaleModel model);
        Task EditAsync(EditSaleModel model);
        Task DeleteAsync(int id);
    }
}
