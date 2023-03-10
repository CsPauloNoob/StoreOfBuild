using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StoreOfBuild.Domain.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreOfBuild.Data.Identity
{
    public class Manager : IManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _dbContext;

        public Manager(UserManager<ApplicationUser> userManager, 
                       SignInManager<ApplicationUser> signInManager,
                       ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
        }



        public async Task<bool> CreateAsync(string email, string password, string role)
        {
            try
            {
                var user = new ApplicationUser { UserName = email, Email = email };
                var result = await _userManager.CreateAsync(user, password);
                var roles = await _userManager.GetRolesAsync(user);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, role);
                    return true;
                }

                return false;
            }

            catch(Exception ex)
            {
                return false;
            }
        }

        public List<IUser> ListAll()
        {

            var users = _dbContext.Users;

            return users.Any() ? users.Select(u => (IUser)u).ToList() : new List<IUser>();
        }
    }
}