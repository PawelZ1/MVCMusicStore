using FluentAssertions;
using MVCMusicStore.Core.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMusicStore.UnitTests.Models
{
    [TestFixture]
    public class UserAddressTests
    {
        public UserAddress CreateUserAddress()
        {
            return new UserAddress("111", "testAddress1", "testAddress2", "testCity", "33-333", "testState", "testCountry");
        } 

        [Test]
        public void SetAddress_GivenAddress1Empty_ThrowsError()
        {
            var address = CreateUserAddress();

            Assert.Throws<Exception>(() => address.SetAddress("", ""));
        }

        [Test]
        public void SetAddress_GivenAddress1String_SetsAddress1()
        {
            var address = CreateUserAddress();

            address.SetAddress("sampleAddress1", "sampleAddress2");

            address.Address1.Should().Be("sampleAddress1");
        }

        [TestCase(null)]
        [TestCase("")]
        public void SetAddress_GivenAddress2Empty_SetsAddress2Empty(string address2)
        {
            var address = CreateUserAddress();

            address.SetAddress("sampleAddress", address2);

            address.Address2.Should().BeNullOrWhiteSpace();
        }

        [Test]
        public void SetCity_GivenEmptyString_ThrowsException()
        {
            var address = CreateUserAddress();

            Assert.Throws<Exception>(() => address.SetCity(""));
        }

        [Test]
        public void SetCity_GivenString_SetsCity()
        {
            var address = CreateUserAddress();

            address.SetCity("sampleCity");

            address.City.Should().Be("sampleCity");
        }

        [Test]
        public void SetZipCode_GivenEmptyString_ThrowsException()
        {
            var address = CreateUserAddress();

            Assert.Throws<Exception>(() => address.SetZipCode(""));
        }

        [Test]
        public void SetZipCode_GivenString_SetsZipCode()
        {
            var address = CreateUserAddress();

            address.SetZipCode("44-444");

            address.ZipCode.Should().Be("44-444");
        }

        [Test]
        public void SetState_GivenEmptyString_ThrowsException()
        {
            var address = CreateUserAddress();

            Assert.Throws<Exception>(() => address.SetState(""));
        }

        [Test]
        public void voidSetState_GivenString_SetsState()
        {
            var address = CreateUserAddress();

            address.SetState("sampleState");

            address.State.Should().Be("sampleState");
        }

        [Test]
        public void SetCountry_GivenEmptyString_ThrowsException()
        {
            var address = CreateUserAddress();

            Assert.Throws<Exception>(() => address.SetCountry(""));
        }

        [Test]
        public void SetCountry_GivenString_SetsCountry()
        {
            var address = CreateUserAddress();

            address.SetCountry("sampleCountry");

            address.Country.Should().Be("sampleCountry");
        }
    }
}
