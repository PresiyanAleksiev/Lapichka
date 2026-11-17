using Microsoft.AspNetCore.Identity;

namespace Lapichka.Models;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public DateTime RegisteredOn { get; set; } = DateTime.Now;

    // Статус: активен / блокиран
    public bool IsBlocked { get; set; }
}
