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
        private Mapper<ApplicationUser, ApplicationUserViewModel> _mapper;
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
            _mapper = new Mapper<ApplicationUser, ApplicationUserViewModel>();
        }

        public async Task<SignInResult> Login(ApplicationUserViewModel viewModel)
        {
            if (viewModel.Email != null && viewModel.Email.Length > 0 && viewModel.Password != null && viewModel.Password.Length > 0)
            {
                SignInResult result = await _signInManager.PasswordSignInAsync(
                    userName: viewModel.Email,
                    password: viewModel.Password,
                    isPersistent: true,
                    lockoutOnFailure: false);

                return result;
            }

            return SignInResult.Failed;
        }

        public async Task<IdentityResult> Register(ApplicationUserViewModel viewModel)
        {
            if (viewModel.Email != null && viewModel.Email.Length > 0 && viewModel.Password != null && viewModel.Password.Length > 0)
            {
                ApplicationUser user = _mapper.ViewModelToEntity(new ApplicationUser(), viewModel);

                IdentityResult result = await _userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
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
