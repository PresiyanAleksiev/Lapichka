using Lapichka.Models;
using Microsoft.AspNetCore.Identity;

namespace Lapichka.Data;

public static class DbSeeder
{
    public const string AdminRole = "Administrator";
    public const string EmployeeRole = "Employee";
    public const string UserRole = "RegisteredUser";

    public static async Task SeedAsync(IServiceProvider services)
    {
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

        // Роли
        foreach (var role in new[] { AdminRole, EmployeeRole, UserRole })
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));
        }

        // Един начален администратор (по заданието)
        const string adminEmail = "admin@lapichka.bg";
        if (await userManager.FindByEmailAsync(adminEmail) == null)
        {
            var admin = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                FirstName = "Админ",
                LastName = "Лапичка",
                PhoneNumber = "0888123456",
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(admin, "Admin123");
            if (result.Succeeded)
                await userManager.AddToRoleAsync(admin, AdminRole);
        }
    }
}
