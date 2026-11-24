using System.ComponentModel.DataAnnotations;

namespace Lapichka.Models;

// Вид животно (куче, котка, заек...). Администраторът добавя и редактира, но не изтрива.
public class Species
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Въведете вид")]
    [StringLength(50)]
    [Display(Name = "Вид")]
    public string Name { get; set; } = "";

    public ICollection<Animal> Animals { get; set; } = new List<Animal>();
}
