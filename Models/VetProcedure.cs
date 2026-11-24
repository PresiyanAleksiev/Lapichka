using System.ComponentModel.DataAnnotations;
using Lapichka.Validation;

namespace Lapichka.Models;

public class VetProcedure
{
    public int Id { get; set; }

    public int AnimalId { get; set; }
    public Animal? Animal { get; set; }

    [Display(Name = "Вид процедура")]
    public ProcedureType Type { get; set; }

    [DataType(DataType.Date)]
    [NotInFuture(ErrorMessage = "Датата не може да е по-късно от днес")]
    [Display(Name = "Дата на извършване")]
    public DateTime PerformedOn { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "Въведете ветеринарен лекар")]
    [StringLength(100)]
    [Display(Name = "Ветеринарен лекар")]
    public string Veterinarian { get; set; } = "";

    [StringLength(500)]
    [Display(Name = "Бележки")]
    public string? Notes { get; set; }
}
