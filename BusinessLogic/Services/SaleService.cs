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
    public class SaleService : ISaleService
    {
        private readonly IRepository<Sale> saleRepo;
        private readonly IMapper mapper;

        public SaleService(IRepository<Sale> saleRepo, IMapper mapper)
        {
            this.saleRepo = saleRepo;
            this.mapper = mapper;
        }

        public async Task CreateAsync(CreateSaleModel model)
        {
            var saleEntity = mapper.Map<Sale>(model);
            await saleRepo.InsertAsync(saleEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var item = await saleRepo.GetByIDAsync(id);

            if (item == null)
            {
                throw new HttpException(ExceptionMessages.ClientNotFound, HttpStatusCode.NotFound);
            }

            await saleRepo.DeleteAsync(item);
        }

        public async Task EditAsync(EditSaleModel model)
        {
            var saleEntity = mapper.Map<Sale>(model);
            await saleRepo.UpdateAsync(saleEntity);
        }


        public async Task<List<SaleDto>> GetAsync()
        {
            var items = await saleRepo.GetAsync();
            return mapper.Map<List<SaleDto>>(items);
        }

        public async Task<SaleDto?> GetAsync(int id)
        {
            var item = await saleRepo.GetByIDAsync(id);
            if (item == null)
            {
                throw new HttpException(ExceptionMessages.ClientNotFound, HttpStatusCode.NotFound);
            }
            return mapper.Map<SaleDto>(item);
        }
    }
}
