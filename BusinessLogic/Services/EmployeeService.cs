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

namespace Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> employeeRepo;
        private readonly IMapper mapper;

        public EmployeeService(IRepository<Employee> employeeRepo, IMapper mapper)
        {
            this.employeeRepo = employeeRepo;
            this.mapper = mapper;
        }

        public async Task CreateAsync(CreateEmployeeModel model)
        {
            var employeeEntity = mapper.Map<Employee>(model);
            await employeeRepo.InsertAsync(employeeEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var item = await employeeRepo.GetByIDAsync(id);

            if (item == null)
            {
                throw new HttpException(ExceptionMessages.ClientNotFound, HttpStatusCode.NotFound);
            }

            await employeeRepo.DeleteAsync(item);
        }

        public async Task EditAsync(EditEmployeeModel model)
        {
            var employeeEntity = mapper.Map<Employee>(model);
            await employeeRepo.UpdateAsync(employeeEntity);
        }


        public async Task<List<EmployeeDto>> GetAsync()
        {
            var items = await employeeRepo.GetAsync();
            return mapper.Map<List<EmployeeDto>>(items);
        }

        public async Task<EmployeeDto?> GetAsync(int id)
        {
            var item = await employeeRepo.GetByIDAsync(id);
            if (item == null)
            {
                throw new HttpException(Resources.ExceptionMessages.ClientNotFound, HttpStatusCode.NotFound);
            }
            return mapper.Map<EmployeeDto>(item);
        }
    }
}
