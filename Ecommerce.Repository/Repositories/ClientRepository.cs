using Ecommerce.Core.Entities;
using Ecommerce.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Ecommerce.ApiRepository.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly EcommerceDbContext _dbContext;

        public ClientRepository(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext ??
                throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Guid> CreateClient(Client client)
        {
            var existClient = await _dbContext.Customers.FirstOrDefaultAsync(c => c.Document.Equals(client.Document));
            if (existClient != null)
                throw new Exception("Client with document " + client.Document + " is already registered.");
            await _dbContext.Customers.AddAsync(client);
            await _dbContext.SaveChangesAsync();
            return client.Id;
        }

        public async Task<bool> DesactiveClient(Guid id)
        {
            var client = await GetClientById(id);
            if (client.Active)
            {
                client.Active = false;
                client.DesactiveAt = DateTime.Now;
                return true;
            }
            return false;
        }

        public async Task<Guid> UpdateClient(Guid id, string document)
        {
            var client = await GetClientById(id);
            client.Active = true;
            client.Document = document;
            client.UpdateAt = DateTime.Now;
            await _dbContext.SaveChangesAsync();
            return client.Id;
        }

        public async Task<Client> GetClientById(Guid id)
        {
            var clientById = await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id.Equals(id));
            if (clientById == null)
                throw new Exception("Client by Id not found!");
            return clientById;
        }
    }
}
