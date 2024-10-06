using Microsoft.AspNetCore.Identity;
using sbojWebApp.Models;
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

                if(!context.Cities.Any())
                {
                    context.Cities.AddRange(new List<City>()
                    {
                        new City()
                        {
                            Name = "Shumen",
                            Latitude = 43.21,
                            Longitude = 27.91,
                        },
                        new City()
                        {
                            Name = "Varna",
                            Latitude = 43.28,
                            Longitude = 26.93
                        },
                        new City()
                        {
                            Name = "Sofia",
                            Latitude = 42.69,
                            Longitude = 23.31
                        },
                        new City()
                        {
                            Name = "Plovdiv",
                            Latitude = 38.34,
                            Longitude = 24.24,
                        },
                        new City()
                        {
                            Name = "Vratsa",
                            Latitude = 45.45,
                            Longitude = 23.23,
                        },
                        new City()
                        {
                            Name = "Burgas",
                            Latitude = 43.43,
                            Longitude = 24.54,
                        },
                        new City()
                        {
                            Name = "Smyadovo",
                            Latitude = 111.11,
                            Longitude = 11.11,
                        }
                    });
                    context.SaveChanges();
                }

                if (!context.Companies.Any())
                {
                    context.Companies.AddRange(new List<Company>()
                    {
                        new Company()
                        {
                            Name = "myPos",
                            Description = "myPos description",
                            ImagePath = "/uploads/mypos.png",
                            Website = "https://www.mypos.com/",
                            LinkedIn = "https://www.linkedin.com/company/mypos-official/",
                            Facebook = "https://www.facebook.com/myposofficial/",
                            Instagram = "help@mypos.com",
                            PhoneNumber = "+359 88 409 9228",
                            Recruiters = new List<AppUser>()
                        },
                        new Company()
                        {
                            Name = "Bosch",
                            Description = "Bosch description",
                            ImagePath = "/uploads/bosch.png",
                            Website = "https://www.bosch.bg/",
                            LinkedIn = "https://www.linkedin.com/company/mypos-official/",
                            Facebook = "https://www.facebook.com/myposofficial/",
                            Instagram = "https://www.instagram.com/boschhomebg/",
                            PhoneNumber = "+359 12 345 6789",
                            Recruiters = new List<AppUser>()
                        },
                        new Company()
                        {
                            Name = "Nemetschek",
                            Description = "Nemetschek description",
                            ImagePath = "/uploads/nemetschek.jpg",
                            Website = "https://www.nemetschek.bg/",
                            LinkedIn = "https://www.linkedin.com/company/nemetschek-bulgaria/",
                            Facebook = "https://www.facebook.com/NemetschekBulgaria/",
                            Instagram = "https://www.instagram.com/nemetschek.bulgaria/.bg",
                            PhoneNumber = "+359 01 010 1010",
                            Recruiters = new List<AppUser>()
                        }
                    });
                    context.SaveChanges();
                }
                if (!context.Languages.Any())
                {
                    context.Languages.AddRange(new List<Language>()
                    {
                        new Language()
                        {
                            Name = "C#"
                        },
                        new Language()
                        {
                            Name = "C++"
                        },
                        new Language()
                        {
                            Name = "JavaScript"
                        },
                        new Language()
                        {
                            Name = "Java"
                        },
                        new Language()
                        {
                            Name = "Python"
                        },
                        new Language()
                        {
                            Name = "Ruby"
                        },
                        new Language()
                        {
                            Name = "mongoDB"
                        },
                        new Language()
                        {
                            Name = "SQL"
                        },
                        new Language()
                        {
                            Name = ".NET"
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
        
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRole.Applicant))
                    await roleManager.CreateAsync(new IdentityRole(UserRole.Applicant));
                if (!await roleManager.RoleExistsAsync(UserRole.Recruiter))
                    await roleManager.CreateAsync(new IdentityRole(UserRole.Recruiter));
                if (!await roleManager.RoleExistsAsync(UserRole.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRole.Admin));


                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string appAdminEmail = "n.valchanov09@gmail.com";
                string appAdminPassword = "Admin@1234?";

                var appAdmin = await userManager.FindByEmailAsync(appAdminEmail);
                if (appAdmin == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "NValchanov09",
                        Email = appAdminEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, appAdminPassword);
                    await userManager.AddToRoleAsync(newAdminUser, UserRole.Admin);
                }

                string appApplicantEmail = "niki.venelinov@gmail.com";
                string appApplicantPassword = "Applicant@1234";

                var appApplicant = await userManager.FindByEmailAsync(appApplicantEmail);
                if (appApplicant == null)
                {
                    var newApplicantUser = new AppUser()
                    {
                        UserName = "user",
                        Email = appApplicantEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newApplicantUser, appApplicantPassword);
                    await userManager.AddToRoleAsync(newApplicantUser, UserRole.Applicant);
                }

                string appRecruiterEmail = "nikolay.valchanov2009@gmail.com";
                string appRecruiterPassword = "Recruiter@1234";

                var appRecruiter = await userManager.FindByEmailAsync(appRecruiterEmail);
                if (appApplicant == null)
                {
                    var newRecruiterUser = new AppUser()
                    {
                        UserName = "rosen",
                        Email = appRecruiterEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newRecruiterUser, appRecruiterPassword);
                    await userManager.AddToRoleAsync(newRecruiterUser, UserRole.Recruiter);
                }
            }
        }
    }
}