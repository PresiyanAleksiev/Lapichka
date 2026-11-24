using Lapichka.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
        var db = services.GetRequiredService<ApplicationDbContext>();

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

        await SeedAnimalsAsync(db);
    }

    // Начални видове и няколко примерни животни, за да не е празен сайтът
    private static async Task SeedAnimalsAsync(ApplicationDbContext db)
    {
        if (!await db.Species.AnyAsync())
        {
            db.Species.AddRange(
                new Species { Name = "Куче" },
                new Species { Name = "Котка" },
                new Species { Name = "Заек" });
            await db.SaveChangesAsync();
        }

        if (await db.Animals.AnyAsync()) return;

        var dog = await db.Species.FirstAsync(s => s.Name == "Куче");
        var cat = await db.Species.FirstAsync(s => s.Name == "Котка");
        var rabbit = await db.Species.FirstAsync(s => s.Name == "Заек");

        var rex = new Animal
        {
            Name = "Рекс", SpeciesId = dog.Id, Breed = "Немска овчарка", Age = 4, Gender = Gender.Male,
            Description = "Спокоен и предан. Обича разходки и се разбира с деца. Научен е на основни команди."
        };
        rex.VetProcedures.Add(new VetProcedure
        {
            Type = ProcedureType.Vaccination, PerformedOn = DateTime.Today.AddMonths(-2),
            Veterinarian = "д-р Иванова", Notes = "Годишна ваксина против бяс"
        });
        rex.VetProcedures.Add(new VetProcedure
        {
            Type = ProcedureType.Castration, PerformedOn = DateTime.Today.AddMonths(-5),
            Veterinarian = "д-р Петров"
        });

        var mia = new Animal
        {
            Name = "Мия", SpeciesId = cat.Id, Age = 2, Gender = Gender.Female,
            Description = "Игрива и любопитна котка. Използва котешка тоалетна и обича да се гушка."
        };
        mia.VetProcedures.Add(new VetProcedure
        {
            Type = ProcedureType.Deworming, PerformedOn = DateTime.Today.AddDays(-20),
            Veterinarian = "д-р Иванова"
        });

        var bella = new Animal
        {
            Name = "Бела", SpeciesId = dog.Id, Breed = "Смесена", Age = 1, Gender = Gender.Female,
            Description = "Енергично кученце, което има нужда от двор и активни стопани."
        };

        var snejko = new Animal
        {
            Name = "Снежко", SpeciesId = rabbit.Id, Breed = "Холандско джудже", Age = 3, Gender = Gender.Male,
            Description = "Кротък заек, подходящ за апартамент. Обича моркови и тишина."
        };
        snejko.VetProcedures.Add(new VetProcedure
        {
            Type = ProcedureType.Checkup, PerformedOn = DateTime.Today.AddDays(-7),
            Veterinarian = "д-р Георгиев", Notes = "Здрав, без забележки"
        });

        var tom = new Animal
        {
            Name = "Том", SpeciesId = cat.Id, Age = 7, Gender = Gender.Male,
            Description = "Възрастен и спокоен котарак. Търси тих дом.",
            Status = AnimalStatus.Adopted
        };

        db.Animals.AddRange(rex, mia, bella, snejko, tom);
        await db.SaveChangesAsync();
    }
}
