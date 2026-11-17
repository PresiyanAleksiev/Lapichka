using Microsoft.AspNetCore.Mvc;

namespace Lapichka.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();
}
