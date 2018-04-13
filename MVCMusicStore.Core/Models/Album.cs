using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMusicStore.Core.Models
{
    public class Album
    {
        [Key]
        public Guid AlbumId { get; private set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; private set; }
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public virtual ICollection<Artist> Artists { get; set; }

        public virtual Guid? GenreId { get; set; }
        public virtual Genre Genre { get; set; }

        public Album(Guid albumId, string title, decimal price)
        {
            AlbumId = albumId;
            SetTitle(title);
            SetPrice(price);
            Update();
        }

        public void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException();
            Title = title;
            Update();
        }

        public void SetPrice(decimal price)
        {
            if (price < 0)
                throw new ArgumentException();
            Price = price;
            Update();
        }

        private void Update()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
