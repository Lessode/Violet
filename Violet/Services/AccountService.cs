using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Violet.Entities;
using Violet.Helpers;
using Violet.Models;
using Violet.Repositories;
using Violet.Services.Interfaces;

namespace Violet.Services
{
    public class AccountService : IAccountService
    {
        private readonly IGenericRepository<ApplicationUser> _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IGenericRepository<ApplicationUser> userRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userRepository = userRepository;
        }

        public async Task<SignInResult> Login(string email, string password)
        {
            if (email != null && email.Length > 0 && password != null && password.Length > 0)
            {
                SignInResult result = await _signInManager.PasswordSignInAsync(
                    userName: email,
                    password: password,
                    isPersistent: true,
                    lockoutOnFailure: false);

                return result;
            }

            return SignInResult.Failed;
        }

        public async Task<IdentityResult> Register(string email, string password)
        {
            if (email != null && email.Length > 0 && password != null && password.Length > 0)
            {
                IdentityResult result = await _userManager.CreateAsync(new ApplicationUser() { Email = email }, password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(new ApplicationUser() { Email = email }, isPersistent: false);
                }

                return result;
            }

            return new IdentityResult();
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
