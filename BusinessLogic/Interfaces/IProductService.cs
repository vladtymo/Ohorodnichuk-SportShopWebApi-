using BusinessLogic.ApiModels;
using BusinessLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IProductService
    {
        Task <List<ProductDto>> GetAsync();
        Task<ProductDto?> GetAsync(int id);
        Task CreateAsync(CreateProductModel model);
        Task EditAsync(EditProductModel model);
        Task DeleteAsync(int id);
    }
}
