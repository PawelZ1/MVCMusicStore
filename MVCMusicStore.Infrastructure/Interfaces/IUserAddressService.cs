using MVCMusicStore.Core.Models;
using MVCMusicStore.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMusicStore.Infrastructure.Interfaces
{
    public interface IUserAddressService
    {
        Task<UserAddressDTO> GetAddressAsync(string id);
        Task CreateAddressAsync(UserAddressDTO address);
        Task UpdateAdressAsync(UserAddressDTO address);
        Task RemoveUserAddressAsync(string id);
    }
}
