using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<bool> CreateAccount(ApplicationUserViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                IdentityResult result = await _accountSerivce.Register(viewModel);

                if(result.Succeeded)
                {
                    return true;
                }
            }

            return false;
        }
    }
}