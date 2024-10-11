using Microsoft.AspNetCore.Identity;
using sbojWebApp.Models;
using sbojWebApp.Data;
using System.Diagnostics;
using System.Net;
using Newtonsoft.Json;

namespace sbojWebApp.Data
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
                    var cities = LoadSeedDataFromJson<City>("cities.json");
                    context.Cities.AddRange(cities);
                    context.SaveChanges();
                }
            }
        }

		private static List<T> LoadSeedDataFromJson<T>(string fileName) where T : class
		{
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", fileName);
            Console.WriteLine($"Data exported to {filePath}");

            if(!File.Exists(filePath))
				return new List<T>();

			var jsonData = File.ReadAllText(filePath);
			var data = JsonConvert.DeserializeObject<List<T>>(jsonData);

            foreach (var item in data)
            {
                var idProperty = typeof(T).GetProperty("Id");
                if (idProperty != null && idProperty.PropertyType == typeof(int))
                {
                    idProperty.SetValue(item, 0);
                }
            }

            return data ?? new List<T>();
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