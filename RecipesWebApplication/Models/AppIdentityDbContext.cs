using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesWebApplication.Models
{
    public class AppIdentityDbContext : IdentityDbContext<IdentityUser/*identify users in the application*/>
    {
            public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
                : base(options) { }

    }
}
