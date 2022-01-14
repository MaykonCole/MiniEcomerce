using Ecommerce.Core.Entities;
using Ecommerce.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.ApiRepository.Repositories
{
    public class PhoneRepository : IPhoneRepository
    {
        private readonly EcommerceDbContext _dbContext;

        public PhoneRepository(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext ??
                throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task CreatePhone(List<Phone> phones)
        {
            foreach (var phone in phones)
            {
                var phoneExists = await _dbContext.Phones.FirstOrDefaultAsync(
                    p => p.Number.Equals(phone.Number) && p.Client.Id.Equals(phone.Client.Id));
                if (phoneExists != null)
                    continue;
                await _dbContext.Phones.AddAsync(phone);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Guid> UpdatePhone(Guid idClient, Phone phone)
        {
            var client = await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id.Equals(idClient));
            if (client == null)
                throw new Exception("Client not found!");
            phone.Client = client;

            var myPhone = await FindPhoneByNumberAndId(idClient, phone.Number);

            myPhone.Number = phone.Number;
            myPhone.UpdateAt = DateTime.Now;
            myPhone.MainContact = phone.MainContact;
            myPhone.IsWhatSap = phone.IsWhatSap;
            myPhone.Client = phone.Client;
            myPhone.Active = true;

            await _dbContext.SaveChangesAsync();
            return myPhone.Id;
        }

        public async Task<bool> DesactivePhone(Guid idClient, string number)
        {
           var phone = await FindPhoneByNumberAndId(idClient, number);

            if (phone.Active == true)
            {
                phone.Active = false;
                phone.DesactiveAt = DateTime.Now;

                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Phone> FindPhoneByNumberAndId(Guid idClient, string number)
        {
            var phone = await _dbContext.Phones.FirstOrDefaultAsync(p => p.Number.Equals(number)
           && p.Client.Id.Equals(idClient));
            if (phone == null)
                throw new Exception("Phone not found!");
            return phone;
        }
    }
}
