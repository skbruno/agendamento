using Microsoft.AspNetCore.Mvc;

namespace Agendamento_app.Controllers
{
    public class SettingController : Controller
    {
        public IActionResult Configuracoes()
        {
            return View();
        }
    }
}
