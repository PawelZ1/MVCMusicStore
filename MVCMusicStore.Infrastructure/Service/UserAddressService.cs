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

        public async Task CreateAddressAsync(UserAddressDTO address)
        {
            if (address == null)
                throw new ArgumentNullException();
            var user = new UserAddress(address.UserAddressId, address.Address1, address.Address2, address.City, address.ZipCode, address.State, address.Country);
            await _userAddress.CreateAsync(user);
        }

        public async Task<UserAddressDTO> GetAddressAsync(string id)
        {
            var userAddress = await _userAddress.GetAsync(id);
            if (userAddress == null)
                return null;
            return new UserAddressDTO
            {
                UserAddressId = userAddress.UserAddressId,
                Address1 = userAddress.Address1,
                Address2 = userAddress.Address2,
                City = userAddress.City,
                ZipCode = userAddress.ZipCode,
                State = userAddress.State,
                Country = userAddress.Country
            };
        }

        public async Task RemoveUserAddressAsync(string id)
        {
            if (id == null)
                throw new ArgumentNullException();
            await _userAddress.RemoveAsync(id);
        }

        public async Task UpdateAdressAsync(UserAddressDTO address)
        {
            if (address == null)
                throw new ArgumentNullException();
            var user = new UserAddress(address.UserAddressId, address.Address1, address.Address2, address.City, address.ZipCode, address.State, address.Country);
            await _userAddress.UpdateAsync(user);
        }
    }
}
