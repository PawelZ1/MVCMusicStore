using MVCMusicStore.Core.Interfaces;
using MVCMusicStore.Core.Models;
using MVCMusicStore.Infrastructure.DTOs;
using MVCMusicStore.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMusicStore.Infrastructure.Service
{
    public class UserAddressService : IUserAddressService
    {
        private readonly IUserAddressRepository _userAddress;

        public UserAddressService(IUserAddressRepository userAddress)
        {
            _userAddress = userAddress;
        }

        public async Task CreateAddress(UserAddressDTO address)
        {
            var user = new UserAddress(address.UserAddressId, address.Address1, address.Address2, address.City, address.ZipCode, address.State, address.Country);
            await _userAddress.CreateAsync(user);
        }

        public async Task<UserAddressDTO> GetAddress(string id)
        {
            var user = await _userAddress.GetAsync(id);
            if (user == null)
                return null;
            return new UserAddressDTO
            {
                Address1 = user.Address1,
                Address2 = user.Address2,
                City = user.City,
                ZipCode = user.ZipCode,
                State = user.State,
                Country = user.Country
            };
        }

        public async Task RemoveUserAddress(string id)
        {
            await _userAddress.RemoveAsync(id);
        }

        public async Task UpdateAdressAsync(UserAddressDTO address)
        {
            var user = new UserAddress(address.UserAddressId, address.Address1, address.Address2, address.City, address.ZipCode, address.State, address.Country);
            await _userAddress.UpdateAsync(user);
        }
    }
}
