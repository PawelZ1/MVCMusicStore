using MVCMusicStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMusicStore.Core.Interfaces
{
    public interface IUserAddressRepository
    {
        Task<UserAddress> GetAsync(string id);
        Task CreateAsync(UserAddress address);
        Task UpdateAsync(UserAddress address);
        Task RemoveAsync(string id);
    }
}
