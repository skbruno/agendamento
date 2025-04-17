using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Agendamento_app.Models;

namespace Agendamento_app.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;

        public DashboardController(ILogger<DashboardController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
