using System.ComponentModel.DataAnnotations;

namespace Lapichka.Models;

// Кандидатура за доброволец. Името, имейлът и телефонът се вземат от профила на потребителя (User).
public class VolunteerApplication
{
    public int Id { get; set; }

    public string UserId { get; set; } = "";
    public ApplicationUser? User { get; set; }

    [Display(Name = "Предпочитана дейност")]
    public VolunteerActivity PreferredActivity { get; set; }

    [Display(Name = "Дни на разположение")]
    public WeekDays AvailableDays { get; set; }

    [Required(ErrorMessage = "Въведете кратко съобщение")]
    [StringLength(1000)]
    [Display(Name = "Съобщение")]
    public string Message { get; set; } = "";

    [Display(Name = "Дата на подаване")]
    public DateTime SubmittedOn { get; set; } = DateTime.Now;

    [Display(Name = "Статус")]
    public VolunteerStatus Status { get; set; } = VolunteerStatus.New;
}
