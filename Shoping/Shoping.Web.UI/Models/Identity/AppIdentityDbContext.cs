using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoping.Web.UI.Models.Identity
{
    public class AppIdentityDbContext:IdentityDbContext<AppUser,AppRole,string>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            const string ADMIN_ID = "8005b0dc-ae8f-478d-9f97-b2851d9511c5";
            const string ROLE_ID = ADMIN_ID;
            base.OnModelCreating(builder);
            builder.Entity<AppRole>().HasData(new AppRole
            {
                Id = ROLE_ID,
                RoleLevel = "Admin",
                Name = "Admin",
                NormalizedName = "ADMIN",

            },
            new AppRole
            {
                
                RoleLevel = "8005b0dc-ae8f-478d-9f97-b2851d9511c5",
                Name = "Shop",
                NormalizedName = "SHOP",

            }
            );
            builder.Entity<AppUser>().HasData(new {


                Id = ADMIN_ID,
                UserName = "alinouriare",
                AccessFailedCount=0,
                NormalizedUserName = "ALINOURIARE",
                Email = "alinouriare@yahoo.com",
                NormalizedEmail = "ALINOURIARE@YAHOO.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEMDYhBQ5TSFRxozAE0HvCLWJBOIidn2wg7DhIBLNlw0tNxHaBhrJEY/U1UpvM/QHIg==",
                SecurityStamp = "2635MHXDXFOW52EX2CNWUIUI3E63H3WY",
                ConcurrencyStamp = "3a082ba6-d7bb-4bfd-b4ad-e9cb130822f5",
                LockoutEnabled=true,
                PhoneNumberConfirmed=false,
                TwoFactorEnabled=false,
                FirstName="Ali",
                LastName="Nouri",
                PhoneNumber="09359504672"


            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> {

                RoleId = ROLE_ID,
                UserId = ADMIN_ID

            });
        }
    }
}
