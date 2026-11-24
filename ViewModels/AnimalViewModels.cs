using Lapichka.Models;

namespace Lapichka.ViewModels;

// Списък с животни, търсещи дом – търсене по име/вид и страниране
public class AnimalListViewModel
{
    public List<Animal> Animals { get; set; } = new();
    public List<Species> AllSpecies { get; set; } = new();

    public string? Search { get; set; }
    public int? SpeciesId { get; set; }

    public int Page { get; set; } = 1;
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }
}
