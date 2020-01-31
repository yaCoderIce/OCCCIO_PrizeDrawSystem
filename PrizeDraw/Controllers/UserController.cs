using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PrizeDraw.DataLayer;
using PrizeDraw.DataLayer.DataAccess;
using PrizeDraw.DataLayer.Model;
using PrizeDraw.DataLayer.Model.Identity;
using PrizeDraw.Identity;
using PrizeDraw.Models;
/// <summary>
/// Generate new user
/// </summary>
namespace PrizeDraw.Controllers
{
    public class UserController : Controller
    {
        private UserDataAccessor _userDataAccessor;
        private RoleDataAccessor _roleDataAccessor;
        private VendorDataAccessor _vendorDataAccessor;

        private UserManager<User> _userManager;
        
        public UserController(PrizeDrawDatabaseContext context,
            UserManager<User> userManager)
        {
            _userDataAccessor = new UserDataAccessor(context);
            _roleDataAccessor = new RoleDataAccessor(context);
            _vendorDataAccessor = new VendorDataAccessor(context);

            _userManager = userManager;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View(_userDataAccessor.Get());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View("CreateEdit", GetCreateEditViewModel());
        }

        private UserCreateEditViewModel GetCreateEditViewModel()
        {
            UserCreateEditViewModel viewModel = new UserCreateEditViewModel();

            viewModel.FillVendorsList(_vendorDataAccessor.Get());
            viewModel.FillRolesList(_roleDataAccessor.Get());

            return viewModel;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(UserCreateEditViewModel userModel)
        {
            IActionResult result;

            if (ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(userModel.Password))
                {
                    ModelState.AddModelError("Password", "Password cannot be blank");
                    result = View("CreateEdit", GetCreateEditViewModel());
                }
                else
                {
                    User user = new User()
                    {
                        UserName = userModel.UserName,
                        VendorId = userModel.VendorId
                    };
                    
                    IdentityResult identityResult = await _userManager.CreateAsync(user, userModel.Password);

                    if (identityResult.Succeeded)
                    {
                        identityResult = await _userManager.AddToRolesAsync(user, userModel.Roles);
                    }
                    if (identityResult.Succeeded)
                    {
                        result = RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (IdentityError error in identityResult.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }

                        result = View("CreateEdit", GetCreateEditViewModel());
                    }
                }
            }
            else
            {
                result = View("CreateEdit", GetCreateEditViewModel());
            }

            return result;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            return CreateEditView(id);
        }

        private IActionResult CreateEditView(int userId)
        {
            User user = _userDataAccessor.Get(userId);

            UserCreateEditViewModel viewModel = new UserCreateEditViewModel
            {
                UserName = user.UserName,
                Roles = user.UserRoles.Select(r => r.Role.Name).ToList(),
                VendorId = user.VendorId.GetValueOrDefault()
            };

            viewModel.FillVendorsList(_vendorDataAccessor.Get());
            viewModel.FillRolesList(_roleDataAccessor.Get());

            return View("CreateEdit", viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, string password, int? vendorId, IList<string> roles)
        {
            IActionResult result;

            if (ModelState.IsValid)
            {
                User user = _userDataAccessor.Get(id);
                user.VendorId = vendorId;

                IdentityResult identityResult = await _userManager.UpdateAsync(user);

                if (identityResult.Succeeded && !string.IsNullOrWhiteSpace(password))
                {
                    identityResult = await ((ApplicationUserManager)_userManager).ChangePasswordAsync(user, password);
                }

                if(identityResult.Succeeded)
                {
                    _roleDataAccessor.ClearUserRoles(id);

                    identityResult = await _userManager.AddToRolesAsync(user, roles);
                }

                if (identityResult.Succeeded)
                {
                    result = RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in identityResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }

                    result = CreateEditView(id);
                }
            }
            else
            {
                result = RedirectToAction("Edit");
            }

            return result;
        }
    }
}