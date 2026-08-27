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

            // Ensure Admin role exists
            IdentityRole adminRole;
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                adminRole = new IdentityRole("Admin");
                await roleManager.CreateAsync(adminRole);
            }
            else
            {
                adminRole = await roleManager.FindByNameAsync("Admin");
            }

            // Sync all permissions to the Admin role
            var allPermissions = AppPermissions.GetAllPermissions();
            var existingClaims = await roleManager.GetClaimsAsync(adminRole);
            var existingPermissionClaims = existingClaims.Where(c => c.Type == "Permission").Select(c => c.Value).ToList();
            
            foreach (var permission in allPermissions)
            {
                if (!existingPermissionClaims.Contains(permission))
                {
                    await roleManager.AddClaimAsync(adminRole, new System.Security.Claims.Claim("Permission", permission));
                }
            }

            // Check if any users exist
            if (!userManager.Users.Any())
            {
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
