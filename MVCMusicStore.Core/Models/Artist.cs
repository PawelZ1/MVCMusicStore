using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMusicStore.Core.Models
{
    public class Artist
    {
        public Guid ArtistId { get; private set; }
        public string Name { get; private set; }
        public string Country { get; private set; }

        public Artist(string name, string country)
        {
            ArtistId = Guid.NewGuid();
            Name = name;
            Country = country;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception();

            Name = name;
        }

        public void SetCountry(string country)
        {
            if (string.IsNullOrWhiteSpace(country))
                throw new Exception();

            Country = country;
        }
    }
}
