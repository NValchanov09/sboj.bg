using Microsoft.AspNetCore.Identity;
using sbojWebApp.Models;
using sbojWebApp.Data.Enum;
using sbojWebApp.Data;
using System.Diagnostics;
using System.Net;

namespace RunGroopWebApp.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Cities.Any())
                {
                    context.Cities.AddRange(new List<City>()
                    {
                        new City()
                        {
                            Name = "Sofia",
                            Latitude = 42.69,
                            Longitude = 23.31,
                        },
                        new City()
                        {
                            Name = "Shumen",
                            Latitude = 43.28,
                            Longitude = 26.93,
                        },
                        new City()
                        {
                            Name = "Varna",
                            Latitude = 43.20,
                            Longitude = 27.91,
                        },
                        new City()
                        {
                            Name = "Varna",
                            Latitude = 43.20,
                            Longitude = 27.91,
                        },
                        new City()
                        {
                            Name = "Plovdiv",
                            Latitude = 42.13,
                            Longitude = 24.74,
                        }

                    });
                    context.SaveChanges();
                }
                //Races
                if (!context.Companies.Any())
                {
                    context.Companies.AddRange(new List<Company>()
                    {
                        new Company()
                        {
                            Name = "Nemetschek",
                            Description = "Nemetschek Bulgaria, established in 1998, is a leader in software development for the architecture, engineering, and construction industries. The company fosters innovation and collaboration with global brands, providing a dynamic work environment focused on personal growth and cutting-edge technology solutions​",
                            ImagePath = "/uploads/nemetschek.jpg",
                            Website = "https://www.nemetschek.bg/",
                            Facebook = "https://www.facebook.com/NemetschekBulgaria",

                        }
                    });
                    context.SaveChanges();
                }
            }
        }

        /*public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "teddysmithdeveloper@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "teddysmithdev",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        Address = new Address()
                        {
                            Street = "123 Main St",
                            City = "Charlotte",
                            State = "NC"
                        }
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        Address = new Address()
                        {
                            Street = "123 Main St",
                            City = "Charlotte",
                            State = "NC"
                        }
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }*/
    }
}