namespace NhatDaiShop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using NhatDaiShop.Model.Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NhatDaiShop.Data.NhatDaiShopDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NhatDaiShop.Data.NhatDaiShopDBContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new NhatDaiShopDBContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new NhatDaiShopDBContext()));

            var user = new ApplicationUser()
            {
                UserName = "daigunny12",
                Email = "daigunny12@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "Vo Nhat Dai"
            };

            manager.Create(user, "123654?");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("daigunny12@gmail.com");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }
    }
}