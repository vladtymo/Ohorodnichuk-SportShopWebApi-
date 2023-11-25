using AutoMapper;
using BusinessLogic.ApiModels;
using BusinessLogic.Dtos;
using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Core.Resources;

namespace BusinessLogic.Services
{
    public class ClientService : IClientService
    {
        private readonly IRepository<Client> clientRepo;
        private readonly IMapper mapper;

        public ClientService(IRepository<Client> clientRepo, IMapper mapper)
        {
            this.clientRepo = clientRepo;
            this.mapper = mapper;
        }

        public async Task CreateAsync(CreateClientModel model)
        {
            var clientEntity = mapper.Map<Client>(model);
            await clientRepo.InsertAsync(clientEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var item = await clientRepo.GetByIDAsync(id);

            if (item == null)
            {
                throw new HttpException(ExceptionMessages.ClientNotFound, HttpStatusCode.NotFound);
            }

            await clientRepo.DeleteAsync(item);
        }

        public async Task EditAsync(EditClientModel model)
        {
            var clientEntity = mapper.Map<Client>(model);
            await clientRepo.UpdateAsync(clientEntity);
        }

        public async Task<List<ClientDto>> GetAsync()
        {
            var items = await clientRepo.GetAsync();
            return mapper.Map<List<ClientDto>>(items);
        }

        public async Task<ClientDto?> GetAsync(int id)
        {
            var item = await clientRepo.GetByIDAsync(id);
            if (item == null)
            {
                throw new HttpException(ExceptionMessages.ClientNotFound, HttpStatusCode.NotFound);
            }
            return mapper.Map<ClientDto>(item);
        }
    }
}
