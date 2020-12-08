using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;//useSQLserver
using Microsoft.Extensions.Configuration;//iconfiguration 
using Microsoft.Extensions.DependencyInjection;
using RecipesWebApplication.Models;

namespace RecipesWebApplication
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        //constructor
        public Startup(IConfiguration configuration) => Configuration = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //goes to appsettings.json to get data and connection string info
            //connects database to connection string
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["Data:RecipeWebApplication:ConnectionString"]));


            //connects to identity database using AppIdentityDbContext class
            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(Configuration["Data:RecipeWebAppIdentity:ConnectionString"]));
            //add identity service

            services.AddIdentity<IdentityUser, IdentityRole>()
               .AddEntityFrameworkStores<AppIdentityDbContext>() //help to find the info in the Identity database
               .AddDefaultTokenProviders(); //tokens to help with passwords esp when changing passwords

            services.AddMvc();
            services.AddTransient<IRecipeRepository, EFRecipeRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();
            app.UseStaticFiles();//wwwroot folder access
            app.UseAuthentication();//provide classes etc..  and other services related to authentication provided by dotnet core

            /*Creating the database... if one or more db already exists, 
             cmd--->                      Create |  dotnet ef migrations add RecipeIdentity --context AppIdentityDbContext
                                          Update |  dotnet ef database update --context AppIdentityDbContext
             package manager console -->  Create |  add-migration Initial -context AppIdentityDbContext
                                          Update |  update-database -context AppIdentityDbContext 
             */
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "pagination",
                   template: "Recipes/Page{recipePage}",
                   defaults: new { Controller = "Home", action = "RecipeList" });
                   
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                //routes.MapRoute(
                //    name: "default2",
                //    template: "{controller=Home}/{action}");
            });

            SeedData.EnsurePopulated(app);//hard coded data for recipes, reviews, cusine
            IdentitySeedData.EnsurePopulated(app); // hardcoded data for the users 
        }

    }
}
