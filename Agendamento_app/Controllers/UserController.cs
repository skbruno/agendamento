using Microsoft.AspNetCore.Mvc;

namespace Agendamento_app.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Usuarios()
        {
            return View();
        }
    }
}
