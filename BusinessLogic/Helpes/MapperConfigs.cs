using AutoMapper;
using BusinessLogic.ApiModels;
using BusinessLogic.Dtos;
using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Helpes
{
    public class MapperConfigs : Profile
    {
        public MapperConfigs()
        {
            CreateMap<CreateClientModel, Client>();
            CreateMap<EditClientModel, Client>();

            CreateMap<Client, ClientDto>().ReverseMap();

            CreateMap<CreateEmployeeModel, Employee>();
            CreateMap<BusinessLogic.ApiModels.CreateEmployeeModel, BusinessLogic.Entities.Employee>();
            CreateMap<Employee, EmployeeDto>().ReverseMap();

            CreateMap<CreateProductModel, Product>();
            CreateMap<BusinessLogic.ApiModels.CreateProductModel, BusinessLogic.Entities.Product>();
            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<CreateSaleModel, Sale>();
            CreateMap<BusinessLogic.ApiModels.CreateSaleModel, BusinessLogic.Entities.Sale >();
            CreateMap<Sale, SaleDto>().ReverseMap();
        }
    }
}
