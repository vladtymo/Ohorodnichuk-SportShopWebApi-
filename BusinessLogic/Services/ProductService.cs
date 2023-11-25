using AutoMapper;
using BusinessLogic.ApiModels;
using BusinessLogic.Dtos;
using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Core.Resources;

namespace BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> productRepo;
        private readonly IMapper mapper;

        public ProductService(IRepository<Product> productRepo, IMapper mapper)
        {
            this.productRepo = productRepo;
            this.mapper = mapper;
        }

        public async Task CreateAsync(CreateProductModel model)
        {
            var productEntity = mapper.Map<Product>(model);
            await productRepo.InsertAsync(productEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var item = await productRepo.GetByIDAsync(id);

            if (item == null)
            {
                throw new HttpException(ExceptionMessages.ClientNotFound, HttpStatusCode.NotFound);
            }

            await productRepo.DeleteAsync(item);
        }

        public async Task EditAsync(EditProductModel model)
        {
            var productEntity = mapper.Map<Product>(model);
            await productRepo.UpdateAsync(productEntity);
        }


        public async Task<List<ProductDto>> GetAsync()
        {
            var items = await productRepo.GetAsync();
            return mapper.Map<List<ProductDto>>(items);
        }

        public async Task<ProductDto?> GetAsync(int id)
        {
            var item = await productRepo.GetByIDAsync(id);
            if (item == null)
            {
                throw new HttpException(ExceptionMessages.ClientNotFound, HttpStatusCode.NotFound);
            }
            return mapper.Map<ProductDto>(item);
        }
    }
}
