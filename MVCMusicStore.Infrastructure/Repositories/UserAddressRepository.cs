using MVCMusicStore.Core.Interfaces;
using MVCMusicStore.Core.Models;
using MVCMusicStore.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMusicStore.Infrastructure.Repositories
{
    public class UserAddressRepository : IUserAddressRepository
    {
        private MVCMusicStoreDBContext _context;

        private UserAddressRepository() { }

        public UserAddressRepository(MVCMusicStoreDBContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(UserAddress address)
        {
            if (address == null)
                throw new ArgumentNullException();
            _context.UserAddresses.Add(address);
            await _context.SaveChangesAsync();
        }

        public async Task<UserAddress> GetAsync(string id)
        {
            if (id == null)
                throw new ArgumentNullException();
            return await _context.UserAddresses.SingleOrDefaultAsync(s => s.UserAddressId == id);
        }

        public async Task RemoveAsync(string id)
        {
            if (id == null)
                throw new ArgumentNullException();
            var userAddress = await GetAsync(id);
            _context.UserAddresses.Remove(userAddress);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserAddress address)
        {
            if (address == null)
                throw new ArgumentNullException();
            _context.Entry(address).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
