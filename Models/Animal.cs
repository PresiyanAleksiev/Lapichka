using System.ComponentModel.DataAnnotations;

namespace Lapichka.Models;

public class Animal
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Въведете име")]
    [StringLength(50)]
    [Display(Name = "Име")]
    public string Name { get; set; } = "";

    [Display(Name = "Вид")]
    public int SpeciesId { get; set; }
    public Species? Species { get; set; }

    [StringLength(50)]
    [Display(Name = "Порода")]
    public string? Breed { get; set; }

    [Range(0, 30, ErrorMessage = "Възрастта трябва да е цяло число между 0 и 30")]
    [Display(Name = "Възраст (години)")]
    public int Age { get; set; }

    [Display(Name = "Пол")]
    public Gender Gender { get; set; }

    [Required(ErrorMessage = "Въведете описание")]
    [StringLength(1000)]
    [Display(Name = "Описание")]
    public string Description { get; set; } = "";

    // Относителен път до снимката в wwwroot, напр. /images/animals/abc.jpg
    [StringLength(260)]
    [Display(Name = "Снимка")]
    public string? PhotoPath { get; set; }

    [Display(Name = "Статус")]
    public AnimalStatus Status { get; set; } = AnimalStatus.LookingForHome;

    public DateTime CreatedOn { get; set; } = DateTime.Now;

    public ICollection<VetProcedure> VetProcedures { get; set; } = new List<VetProcedure>();
    public ICollection<AdoptionRequest> AdoptionRequests { get; set; } = new List<AdoptionRequest>();
}
