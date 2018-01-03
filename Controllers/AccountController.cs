using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Violet.Models;
using Violet.Services.Interfaces;

namespace Violet.Controllers
{
    public class AccountController : AbstractController
    {
        public IAccountService _accountSerivce;

        public AccountController(IAccountService accountService)
        {
            _accountSerivce = accountService;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<bool> LogIn(ApplicationUserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _accountSerivce.Login(viewModel);

                if(result.Succeeded)
                {
                    return true;
                }
            }

            return false;
        }

        [HttpPost]
        public async Task<bool> CreateAccount(ApplicationUserViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                IdentityResult result = await _accountSerivce.Register(viewModel);

                if(result.Succeeded)
                {
                    return true;
                }

                AddErrors(result);
            }

            return false;
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.ToString());
            }
        }
    }
}