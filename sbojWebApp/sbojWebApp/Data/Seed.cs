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
                
                if (!context.JobPositions.Any())
                {
                    context.JobPositions.AddRange(new List<JobPosition>()
                    {
                        new JobPosition()
                        {
                            Title = "C++ Developer",
                            Description = "As a Mid C++ Developer you will be responsible for developing and maintaining high quality applications, services and APIs. Your expertise will drive the optimization of performance, scalability, and security of applications.",
                            City = new City()
                            {
                                Name = "Varna",
                                Latitude = 43.20,
                                Longitude = 27.91,
                            },

                            EmploymentRole = "Mid",
                            SalaryLow = 3250,
                            SalaryHigh = 4500,
                            ExperienceLow = 5,
                            ExperienceHigh = 10,
                            VacationDaysLow = 20,
                            VacationDaysHigh = 35,
                            Company = new Company()
                            {
                                Name = "myPos",
                                Description = "myPOS is a leading fintech company offering all-in-one payment solutions for merchants of any size. Trusted by over 200,000 businesses across Europe, myPOS provides innovative tools for in-person, online, and mobile payments, with instant fund settlement and no monthly fees, empowering SMEs to grow and diversify their payment options.",
                                ImagePath = "/uploads/mypos.png",
                                Website = "https://www.mypos.com/",
                                LinkedIn = "https://www.linkedin.com/company/mypos-official/",
                                Facebook = "https://www.facebook.com/myposofficial/",
                                PhoneNumber = "+359 88 409 9228",
                                Email = "help@mypos.com",
                                Recruiters = new List<AppUser>()
                            },
                            RequiredLanguages = new List<Language>()
                            {
                                new Language()
                                {
                                    Name = "C++"
                                },
                                new Language()
                                {
                                    Name = "SQL"
                                },
                                new Language()
                                {
                                    Name = "mongoDB"
                                }
                            },
                            Applications = new List<JobApplication>(),
                        },
                        new JobPosition()
                        {
                            Title = "Skibidi Developer",
                            Description = "As a Entry Skibidi Developer you will be responsible for developing and maintaining high quality applications, services and APIs. Your expertise will drive the optimization of performance, scalability, and security of applications.",
                            CityId = 2,
                            City = new City()
                            {
                                Name = "Shumen",
                                Latitude = 43.28,
                                Longitude = 26.93
                            },

                            EmploymentRole = "Entry",
                            SalaryLow = 100,
                            SalaryHigh = 450,
                            ExperienceLow = 0,
                            ExperienceHigh = 3,
                            VacationDaysLow = 3,
                            VacationDaysHigh = 4,
                            Company = new Company()
                            {
                                Name = "Bosch",
                                Description = "Bosch is a global leader in technology and engineering, offering innovative solutions in mobility, industrial technology, and consumer goods. With a strong focus on sustainability and employee development, Bosch provides an exciting environment for personal growth and cutting-edge projects, driving the future of connected living.",
                                ImagePath = "/uploads/bosch.png",
                                Website = "https://www.bosch.bg/",
                                LinkedIn = "https://www.linkedin.com/company/bosch-bulgaria/",
                                Facebook = "https://www.facebook.com/BoschGlobal",
                                PhoneNumber = "+359 700 10 668",
                                Email = "bosch-bg@bg.bosch.com",
                                Recruiters = new List<AppUser>()
                            },
                            RequiredLanguages = new List<Language>()
                            {
                                new Language()
                                {
                                    Name = "Ruby"
                                },
                                new Language()
                                {
                                    Name = "Java"
                                }
                            },
                            Applications = new List<JobApplication>()
                        },

                    });

                    context.SaveChanges();
                }
                if (!context.JobApplications.Any())
                {
                    context.JobApplications.AddRange(new List<JobApplication>()
                    {
                        new JobApplication()
                        {
                            JobPosition = new JobPosition
                        {
                            Title = "C# (.NET) Developer",
                            Description = "As a Senior .NET Developer you will be responsible for developing and maintaining high quality applications, services and APIs. Your expertise will drive the optimization of performance, scalability, and security of applications.",
                            City = new City()
                            {
                                Name = "Sofia",
                                Latitude = 42.69,
                                Longitude = 23.31
                            },

                            EmploymentRole = "Senior",
                            SalaryLow = 3500,
                            SalaryHigh = 5000,
                            ExperienceLow = 5,
                            ExperienceHigh = 12,
                            VacationDaysLow = 25,
                            VacationDaysHigh = 30,
                            Company = new Company()
                            {
                                Name = "myPos",
                                Description = "myPOS is a leading fintech company offering all-in-one payment solutions for merchants of any size. Trusted by over 200,000 businesses across Europe, myPOS provides innovative tools for in-person, online, and mobile payments, with instant fund settlement and no monthly fees, empowering SMEs to grow and diversify their payment options.",
                                ImagePath = "/uploads/mypos.png",
                                Website = "https://www.mypos.com/",
                                LinkedIn = "https://www.linkedin.com/company/mypos-official/",
                                Facebook = "https://www.facebook.com/myposofficial/",
                                PhoneNumber = "+359 88 409 9228",
                                Email = "help@mypos.com",
                                Recruiters = new List<AppUser>()
                            },
                            RequiredLanguages = new List<Language>()
                            {
                                new Language()
                                {
                                    Name = "C#"
                                },
                                new Language()
                                {
                                    Name = ".NET"
                                },
                                new Language()
                                {
                                    Name = "Python"
                                }
                            },
                            Applications = new List<JobApplication>(),
                        },
                            CoverLetter = new CoverLetter()
                            {
                                Body = "Koe e zeleno, muhesto i kato ti swurshi na glawata, mnogo go obichash?",
                                Conclusion = "maika ti"
                            },
                            Status = false
                        },
                        new JobApplication()
                        {
                            CoverLetter = new CoverLetter()
                            {
                                Body = "Scadadle scadoodle, your dick is now a noodle",
                                Conclusion = "Skibidi conclusion"
                            },
                            Status = true
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
        /*
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
                string adminUserEmail = "n.valchanov09@gmail.com";
                string adminUserPassword = "Admin@1234?";

                var appAdmin = await userManager.FindByEmailAsync(adminUserEmail);
                if (appAdmin == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "NValchanov09",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, adminUserPassword);
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
                        UserName = "user",
                        Email = appRecruiterEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newRecruiterUser, appRecruiterPassword);
                    await userManager.AddToRoleAsync(newRecruiterUser, UserRole.Applicant);
                }
            }
        }
        */
    }
}