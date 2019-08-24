using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace SportsStore.Models.DB
{
    public static class IdentitySeedData
    {
        private const string AdminLogin = "Admin";
        private const string AdminPassword = "Secret123$";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            var userManager = app.ApplicationServices
                                 .GetRequiredService<UserManager<IdentityUser>>();
            var user = await userManager.FindByIdAsync(AdminLogin);
            if (user == null)
            {
                user = new IdentityUser(AdminLogin);
                await userManager.CreateAsync(user, AdminPassword);
            }
        }
    }
}
