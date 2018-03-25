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
    public class ApplicationUserTests
    {
        public ApplicationUser CreateApplicationUser()
        {
            return new ApplicationUser();
        }

        [Test]
        public void SetFirstName_GivenEmptyString_ThrowsError()
        {
            var testUser = CreateApplicationUser();

            Assert.Throws<Exception>(() => testUser.SetFirstName(""));
        }

        [Test]
        public void SetFirstName_GivenString_ChangesFirstName()
        {
            var testUser = CreateApplicationUser();

            testUser.SetFirstName("sampleString");

            testUser.FirstName.Should().Be("sampleString");
        }

        [Test]
        public void SetSurname_GivenEmptyString_ThrowsError()
        {
            var testUser = CreateApplicationUser();

            Assert.Throws<Exception>(() => testUser.SetSurname(""));
        }

        [Test]
        public void SetSurname_GivenString_ChangesSurname()
        {
            var testUser = CreateApplicationUser();

            testUser.SetSurname("sampleString");

            testUser.Surname.Should().Be("sampleString");
        }
    }
}
