using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.IRepositories
{
    public interface IPhoneRepository
    {
        Task CreatePhone( List<Phone> phones);
        Task<Guid> UpdatePhone(Guid idClient, Phone phone);
        Task<bool> DesactivePhone(Guid idClient, string number);
    }
}
