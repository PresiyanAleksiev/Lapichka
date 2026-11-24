using Lapichka.Data;
using Lapichka.Models;
using Lapichka.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lapichka.Controllers;

// Публична част – достъпна за всички, включително гости
public class AnimalsController : Controller
{
    private const int PageSize = 6;
    private readonly ApplicationDbContext _db;

    public AnimalsController(ApplicationDbContext db) => _db = db;

    // GET /Animals?search=рекс&speciesId=1&page=2
    public async Task<IActionResult> Index(string? search, int? speciesId, int page = 1)
    {
        var query = _db.Animals
            .Include(a => a.Species)
            .Where(a => a.Status == AnimalStatus.LookingForHome);

        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim();
            // търсене по име или по име на вида
            query = query.Where(a => a.Name.Contains(term) || a.Species!.Name.Contains(term));
        }

        if (speciesId.HasValue)
            query = query.Where(a => a.SpeciesId == speciesId.Value);

        var total = await query.CountAsync();
        var totalPages = Math.Max(1, (int)Math.Ceiling(total / (double)PageSize));
        page = Math.Clamp(page, 1, totalPages);

        var model = new AnimalListViewModel
        {
            Animals = await query
                .OrderByDescending(a => a.CreatedOn)
                .ThenBy(a => a.Name)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync(),
            AllSpecies = await _db.Species.OrderBy(s => s.Name).ToListAsync(),
            Search = search,
            SpeciesId = speciesId,
            Page = page,
            TotalPages = totalPages,
            TotalCount = total
        };

        return View(model);
    }

    // GET /Animals/Details/5 – детайлна информация + ветеринарни процедури
    public async Task<IActionResult> Details(int id)
    {
        var animal = await _db.Animals
            .Include(a => a.Species)
            .Include(a => a.VetProcedures)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (animal == null) return NotFound();

        animal.VetProcedures = animal.VetProcedures
            .OrderByDescending(p => p.PerformedOn)
            .ToList();

        return View(animal);
    }
}
