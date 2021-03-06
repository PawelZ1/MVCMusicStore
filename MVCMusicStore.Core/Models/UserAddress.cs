﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MVCMusicStore.Core.Models
{
    [Table("UserAddresses", Schema = "dbo")]
    public class UserAddress
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string UserAddressId { get; private set; }
        public virtual ApplicationUser ApplicationUser { get; private set; }

        [Required]
        [MaxLength(200)]
        public string Address1 { get; private set; }
        [MaxLength(200)]
        public string Address2 { get; private set; }
        [Required]
        [MaxLength(50)]
        public string City { get; private set; }
        [Required]
        [MaxLength(20)]
        public string ZipCode { get; private set; }
        [Required]
        [MaxLength(50)]
        public string State { get; private set; }
        [Required]
        [MaxLength(50)]
        public string Country { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private UserAddress() { }

        public UserAddress(string userAddressId, string address1, string address2, string city, string zipCode, string state, string country)
        {
            UserAddressId = userAddressId;
            SetAddress(address1, address2);
            SetCity(city);
            SetZipCode(zipCode);
            SetState(state);
            SetCountry(country);
            Update();
        }

        public void SetAddress(string address1, string address2)
        {
            if (string.IsNullOrWhiteSpace(address1))
                throw new Exception();
            Address1 = address1;
            Address2 = address2;
            Update();
        }

        public void SetCity(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
                throw new Exception();
            City = city;
            Update();
        }

        public void SetZipCode(string zipCode)
        {
            if (string.IsNullOrWhiteSpace(zipCode))
                throw new Exception();
            ZipCode = zipCode;
            Update();
        }

        public void SetState(string state)
        {
            if (string.IsNullOrWhiteSpace(state))
                throw new Exception();
            State = state;
            Update();
        }

        public void SetCountry(string country)
        {
            if (string.IsNullOrWhiteSpace(country))
                throw new Exception();
            Country = country;
            Update();
        }

        private void Update()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
