using FluentAssertions;
using Moq;
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
    public class ArtistTests
    {
        public Artist CreateArtits()
        {
            return new Artist("TestArtist", "SomeCountry");
        }

        [Test]
        public void SetName_GivenEmptyString_ThrowsException()
        {
            var testArtist = CreateArtits();

            Assert.Throws<Exception>(() => testArtist.SetName(""));
        }


        [Test]
        public void SetName_GivenString_ChangesName()
        {
            var testArtist = CreateArtits();

            testArtist.SetName("SomeOtherName");

            testArtist.Name.Should().Be("SomeOtherName");
        }


        [Test]
        public void SetCountry_GivenEmptyString_ThrowsException()
        {
            var testArtist = CreateArtits();

            Assert.Throws<Exception>(() => testArtist.SetCountry(""));
        }


        [Test]
        public void SetCountry_GivenString_ChangesCoutry()
        {
            var testArtist = CreateArtits();

            testArtist.SetCountry("SomeOtherCoutry");

            testArtist.Country.Should().Be("SomeOtherCoutry");
        }
    }
}
