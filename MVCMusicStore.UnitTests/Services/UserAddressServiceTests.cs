using FluentAssertions;
using Moq;
using MVCMusicStore.Core.Interfaces;
using MVCMusicStore.Core.Models;
using MVCMusicStore.Infrastructure.DTOs;
using MVCMusicStore.Infrastructure.Repositories;
using MVCMusicStore.Infrastructure.Service;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMusicStore.UnitTests.Services
{
    [TestFixture]
    public class UserAddressServiceTests
    {
        public Mock<IUserAddressRepository> CreateUserAddressMockRepository()
        {
            UserAddress userAddress = new UserAddress("1", "Example Street", "Example House", "Example City", "11-111", "Example State", "Example Country");

            var mock = new Mock<IUserAddressRepository>();
            mock.Setup(s => s.GetAsync("1")).ReturnsAsync(userAddress);

            return mock;
        }

        [Test]
        public void CreateAddressAsync_GivenNull_ThrowsException()
        {
            UserAddressService addressService = new UserAddressService(CreateUserAddressMockRepository().Object);

            Func<Task> act = async () => await addressService.CreateAddressAsync(null);

            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public async Task CreateAddressAsync_GivenAddress_InvokesRepositoryCreateAsync()
        {
            var mockRepository = CreateUserAddressMockRepository();
            UserAddressService addressService = new UserAddressService(mockRepository.Object);
            UserAddressDTO addressDTO = new UserAddressDTO
            {
                UserAddressId = "2",
                Address1 = "Example Street",
                Address2 = "Example House",
                City = "Example City",
                ZipCode = "11-111",
                State = "Example State",
                Country = "Example Country"
            };

            await addressService.CreateAddressAsync(addressDTO);

            mockRepository.Verify(s => s.CreateAsync(It.Is<UserAddress>(x => x.UserAddressId == "2")), Times.Once);
        }

        [Test]
        public async Task GetAddressAsync_AddressNotExisting_ReturnsNull()
        {
            UserAddressService addressService = new UserAddressService(CreateUserAddressMockRepository().Object);

            var result = await addressService.GetAddressAsync("noAddressUser");

            result.Should().BeNull();
        }

        [Test]
        public async Task GetAddressAsync_AddressExists_ReturnsAddressDTO()
        {
            UserAddressService addressService = new UserAddressService(CreateUserAddressMockRepository().Object);
            UserAddressDTO addressDTO = new UserAddressDTO
            {
                UserAddressId = "1",
                Address1 = "Example Street",
                Address2 = "Example House",
                City = "Example City",
                ZipCode = "11-111",
                State = "Example State",
                Country = "Example Country"
            };

            var result = await addressService.GetAddressAsync("1");

            result.Should().BeEquivalentTo(addressDTO);
        }
        [Test]
        public void RemoveUserAddressAsync_GivenNull_ThrowsException()
        {
            UserAddressService addressService = new UserAddressService(CreateUserAddressMockRepository().Object);

            Func<Task> act = async () => await addressService.RemoveUserAddressAsync(null);

            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public async Task RemoveUserAddressAsync_Id_InvokesRepositoryRemoveAsync()
        {
            var repositoryMock = CreateUserAddressMockRepository();
            UserAddressService addressService = new UserAddressService(repositoryMock.Object);

            await addressService.RemoveUserAddressAsync("1");

            repositoryMock.Verify(p => p.RemoveAsync("1"), Times.Once);
        }

        [Test]
        public void UpdateAdressAsync_GivenNull_ThrowsException()
        {
            var repositoryMock = CreateUserAddressMockRepository();
            UserAddressService addressService = new UserAddressService(repositoryMock.Object);

            Func<Task> act = async () => await addressService.UpdateAdressAsync(null);

            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public async Task UpdateAdressAsync_GivenAddress_InvokesRepositoryUpdateAsync()
        {
            var repositoryMock = CreateUserAddressMockRepository();
            UserAddressService addressService = new UserAddressService(repositoryMock.Object);
            UserAddressDTO addressDTO = new UserAddressDTO
            {
                UserAddressId = "1",
                Address1 = "Example Street",
                Address2 = "Example House",
                City = "Example City",
                ZipCode = "11-111",
                State = "Example State",
                Country = "Example Country"
            };

            await addressService.UpdateAdressAsync(addressDTO);

            repositoryMock.Verify(p => p.UpdateAsync(It.Is<UserAddress>(s => s.UserAddressId == "1")), Times.Once);
        }
    }
}
