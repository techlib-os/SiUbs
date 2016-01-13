using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SiUbs.WebApp.Models
{
    public class SiUbsDatabaseInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("@dmin2016");
            context.Users.Add(new ApplicationUser() { UserName = "admin@siubs.com", PasswordHash = passwordHash.HashPassword("@dmin2016") });
        }
    }
}