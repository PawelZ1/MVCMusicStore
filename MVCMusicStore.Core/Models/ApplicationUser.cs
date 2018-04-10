using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MVCMusicStore.Core.Models
{
    [Table("Users", Schema = "dbo")]
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(100)]
        public string FirstName { get; private set; }
        [MaxLength(100)]
        public string Surname { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public virtual UserAddress Address { get; private set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public void SetFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new Exception();
            FirstName = firstName;
            Update();
        }

        public void SetSurname(string surname)
        {
            if (string.IsNullOrWhiteSpace(surname))
                throw new Exception();
            Surname = surname;
            Update();
        }

        private void Update()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
