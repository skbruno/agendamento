﻿using Microsoft.AspNetCore.Mvc;

namespace Agendamento_app.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Agendamentos()
        { 
            return View();
        }
    }
}
