using System.ComponentModel.DataAnnotations;

namespace Lapichka.Models;

// Заявка за осиновяване. Името, имейлът и телефонът се вземат от профила на потребителя (User).
public class AdoptionRequest
{
    public int Id { get; set; }

    public string UserId { get; set; } = "";
    public ApplicationUser? User { get; set; }

    public int AnimalId { get; set; }
    public Animal? Animal { get; set; }

    [Required(ErrorMessage = "Въведете кратко съобщение")]
    [StringLength(1000)]
    [Display(Name = "Съобщение")]
    public string Message { get; set; } = "";

    [Display(Name = "Дата на подаване")]
    public DateTime SubmittedOn { get; set; } = DateTime.Now;

    [Display(Name = "Статус")]
    public AdoptionStatus Status { get; set; } = AdoptionStatus.New;

    // Служител, обработил заявката, и дата на обработка
    public string? ProcessedById { get; set; }
    public ApplicationUser? ProcessedBy { get; set; }

    [Display(Name = "Дата на обработка")]
    public DateTime? ProcessedOn { get; set; }
}
