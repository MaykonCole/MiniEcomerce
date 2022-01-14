using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Core.IRepositories
{
    public interface IClientRepository
    {
        Task<Guid> CreateClient(Client client);
        Task<bool> DesactiveClient(Guid id);
        Task<Guid> UpdateClient(Guid id, string document);
        Task<Client> GetClientById(Guid id);
    }
}
