using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMusicStore.Core.Models
{
    public class Genre
    {
        [Key]
        public Guid GenreId { get; private set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public virtual ICollection<Album> Albums { get; set; }

        public Genre(Guid genreId, string name)
        {
            GenreId = genreId;
            SetName(name);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException();
            Name = name;
            Update();
        }

        private void Update()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
