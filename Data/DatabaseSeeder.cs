using IPSDesk.Models;
using Microsoft.AspNetCore.Identity;

namespace IPSDesk.Data
{
    public static class DatabaseSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Check if any users exist
            if (!userManager.Users.Any())
            {
                // Ensure Admin role exists
                if (!await roleManager.RoleExistsAsync("Admin"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                }

                // Create default admin user
                var adminUser = new ApplicationUser
                {
                    UserName = "faizan@gmail.com",
                    Email = "faizan@gmail.com",
                    EmailConfirmed = true,
                    FullName = "Faizan",
                    IsActive = true
                };

                var result = await userManager.CreateAsync(adminUser, "Faizan@123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }
}
