using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using StoreOfBuild.Domain.Account;
using System.Threading.Tasks;

namespace StoreOfBuild.Data.Identity
{
    public class Authentication : IAuthentication
    {
        private readonly SignInManager<ApplicationUser> _signInManager;


        public Authentication(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }


        public async Task<bool> Authenticate(string email, string password)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);

                return result.Succeeded;
            }

            catch(Exception ex)
            {
                return false;
            }
        }
    }
}