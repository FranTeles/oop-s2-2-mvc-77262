using Microsoft.AspNetCore.Identity;

namespace oop_s2_2_mvc_77262.Data
{
    public static class UserSeed
    {
        public static async Task SeedUsersAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // ADMIN
            await CreateUser(userManager, "admin@test.com", "Admin123!", "Admin");

            // INSPECTOR
            await CreateUser(userManager, "inspector@test.com", "Admin123!", "Inspector");

            // VIEWER
            await CreateUser(userManager, "viewer@test.com", "Admin123!", "Viewer");
        }

        private static async Task CreateUser(UserManager<IdentityUser> userManager, string email, string password, string role)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(user, password);
                await userManager.AddToRoleAsync(user, role);
            }
        }
    }
}