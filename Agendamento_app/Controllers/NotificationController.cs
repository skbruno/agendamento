using Microsoft.AspNetCore.Mvc;

namespace Agendamento_app.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Notificacoes()
        {
            return View();
        }
    }
}
