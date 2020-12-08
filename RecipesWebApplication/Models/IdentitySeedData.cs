using Microsoft.AspNetCore.Builder;//so we can use IApplicationBuilder
using Microsoft.AspNetCore.Identity;//user manager to manage the users
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesWebApplication.Models
{
    public static class IdentitySeedData
    {
        private const string adminUser = "CuisineAdmin";
        private const string adminPassword = "Cuisine#1";

        //private const string adminUser = "Jarod";
        //private const string adminPassword = "Cuisine#1";

        //private const string adminUser1 = "Hassan";
        //private const string adminPassword1 = "Cuisine#1";

        //private const string adminUser2 = "Eunseok";
        //private const string adminPassword2 = "Cuisine#1";

        //private const string adminUser3 = "Manal";
        //private const string adminPassword3 = "Cuisine#1";

        //private const string adminUser4 = "Shaniquo";
        //private const string adminPassword4 = "Cuisine#1";

        private const string managerUser = "CuisineManager";
        private const string managerPassword = "Cuisine#1";

        private const string adminRoleName = "Admin";
        private const string managerRoleName = "Manager";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            //
            RoleManager<IdentityRole> roleManager = app.ApplicationServices
                .GetRequiredService<RoleManager<IdentityRole>>();

            //admin role
            IdentityRole adminRole = await roleManager.FindByNameAsync(adminRoleName);

            if (adminRole == null)
            {
                adminRole = new IdentityRole(adminRoleName);
                await roleManager.CreateAsync(adminRole);
            }

            //manager role
            IdentityRole managerRole = await roleManager.FindByNameAsync(managerRoleName);

            if (managerRole == null)
            {
                managerRole = new IdentityRole(managerRoleName);
                await roleManager.CreateAsync(managerRole);
            }

            //create access to add, deleted edit users, UM retrive info fron the Identity db
            UserManager<IdentityUser> userManager = app.ApplicationServices
                .GetRequiredService<UserManager<IdentityUser>>();

            //admin user , await requires async method
            IdentityUser user = await userManager.FindByNameAsync(adminUser);

            if (user == null)//if the user is null, we create the user
            {
                user = new IdentityUser(adminUser);
                await userManager.CreateAsync(user, adminPassword);
                await userManager.AddToRoleAsync(user, adminRoleName);
            }
            else
            {
                if (!(await userManager.IsInRoleAsync(user, adminRoleName)))
                {
                    await userManager.AddToRoleAsync(user, adminRoleName);
                }
            }

            //manager user
            IdentityUser managerUserIdentity = await userManager.FindByNameAsync(managerUser);

            if (managerUserIdentity == null)
            {
                managerUserIdentity = new IdentityUser(managerUser);
                await userManager.CreateAsync(managerUserIdentity, managerPassword);
                await userManager.AddToRoleAsync(managerUserIdentity, managerRoleName);
            }
            else
            {
                if (!(await userManager.IsInRoleAsync(managerUserIdentity, managerRoleName)))
                {
                    await userManager.AddToRoleAsync(managerUserIdentity, managerRoleName);
                }
            }

        }
    }
}