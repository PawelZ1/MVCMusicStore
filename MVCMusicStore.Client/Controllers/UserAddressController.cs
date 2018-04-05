using Microsoft.AspNet.Identity;
using MVCMusicStore.Client.Models;
using MVCMusicStore.Infrastructure.DTOs;
using MVCMusicStore.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore.Client.Controllers
{
    [Authorize]
    public class UserAddressController : Controller
    {
        private readonly IUserAddressService _userAddress;

        public UserAddressController(IUserAddressService userAddress)
        {
            _userAddress = userAddress;
        }
        
        // GET: UserAddress
        public async Task<ActionResult> Index()
        {

            var address = await _userAddress.GetAddressAsync(User.Identity.GetUserId());
            if(address == null)
            {
                UserAddressViewModel addressNotGiven = new UserAddressViewModel
                {
                    IsAddressGiven = false
                };
                return View(addressNotGiven);
            }

            UserAddressViewModel addressGiven = new UserAddressViewModel
            {
                IsAddressGiven = true,
                Address1 = address.Address1,
                Address2 = address.Address2,
                City = address.City,
                ZipCode = address.ZipCode,
                State = address.State,
                Country = address.Country
             };
            return View(addressGiven);
        }

        //GET: UserAddress/CreateAddress
        public ActionResult CreateUserAddress()
        {
            return View();
        }

        //POST: UserAddress/CreateAddress
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateUserAddress(UserAddressViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserAddressDTO userAddress = new UserAddressDTO
                {
                UserAddressId = User.Identity.GetUserId(),
                Address1 = model.Address1,
                Address2 = model.Address2,
                City = model.City,
                ZipCode = model.ZipCode,
                State = model.State,
                Country = model.Country
                };
                await _userAddress.CreateAddressAsync(userAddress);
                return RedirectToAction("Index", "UserAddress");
            }
            return View();
        }

        //GET: UserAddress/EditUserAddress
        public ActionResult EditUserAddress()
        {
            return View();
        }

        //POST: UserAddress/EditUserAddress
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditUserAddress(UserAddressViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userToEdit = new UserAddressDTO
                {
                    UserAddressId = User.Identity.GetUserId(),
                    Address1 = model.Address1,
                    Address2 = model.Address2,
                    City = model.City,
                    ZipCode = model.ZipCode,
                    State = model.State,
                    Country = model.Country
                };
                await _userAddress.UpdateAdressAsync(userToEdit);
                return RedirectToAction("Index", "UserAddress");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveUserAddres()
        {
            string id = User.Identity.GetUserId();
            await _userAddress.RemoveUserAddressAsync(id);
            return RedirectToAction("Index", "UserAddress");
        }


    }
}