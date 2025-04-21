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
    public IActionResult Appointments()
    {
        return View();
    }
    public IActionResult Users()
    {
        return View();
    }
    public IActionResult Notifications()
    {
        return View();
    }
    public IActionResult Settings()
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

            return RedirectToAction("Index", "Dashboard");
        }

        ViewBag.Erro = "Email ou senha inválidos";
        return View("Index", "Home");
    }

    [HttpPost]
    public async Task<IActionResult> CreateAccount(string Nome, string email, string senha)
    {
        //var usuario = await _authService.CreateAccount(Nome, email, senha);
        var usuario = false;

        if (usuario == true)
        {
            TempData["ToastMessage"] = "Conta Criada com Sucesso";
            TempData["ToastType"] = "success";
            return RedirectToAction("Index", "Home");

        }

        TempData["ToastMessage"] = "Erro ao criar a conta. Verifique os dados.";
        TempData["ToastType"] = "error";
        return View("CreateAccount");

    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        HttpContext.Session.Remove("Token");
        return RedirectToAction("Index", "Home");
    }

}
