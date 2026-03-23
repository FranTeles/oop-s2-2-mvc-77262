using Microsoft.AspNetCore.Identity;

namespace oop_s2_2_mvc_77262.Data
{
    public static class UserSeed
    {
        public static async Task SeedAdminUserAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string adminEmail = "admin@test.com";
            string adminPassword = "Admin123!";

            var existingUser = await userManager.FindByEmailAsync(adminEmail);

            if (existingUser == null)
            {
                var adminUser = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, adminPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }
}