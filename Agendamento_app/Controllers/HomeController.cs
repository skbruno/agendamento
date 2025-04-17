using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Agendamento_app.Models;
using Agendamento_app.Services;

namespace Agendamento_app.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AuthService _authService;

    public HomeController(ILogger<HomeController> logger, AuthService authService)
    {
        _logger = logger;
        _authService = authService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult RecoverPassword()
    {
        return View();
    }

    public IActionResult CreateAccount()
    {
        return View();
    }

    public IActionResult Dashboard()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string email, string senha)
    {
        var usuario = await _authService.Login(email, senha);

        if (usuario != null && !string.IsNullOrEmpty(usuario.Token))
        {
            HttpContext.Session.SetString("Token", usuario.Token);
            HttpContext.Session.SetString("Nome", usuario.Nome);
            HttpContext.Session.SetString("Email", usuario.Email);

            return RedirectToAction("Dashboard");
        }

        ViewBag.Erro = "Email ou senha inválidos";
        return View("Index");
    }

}
