using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Violet.Models;

namespace Violet.Services.Interfaces
{
    public interface IAccountService
    {
        Task<SignInResult> Login(string email, string password);
        Task<IdentityResult> Register(string email, string password);
        Task Logout();
    }
}
