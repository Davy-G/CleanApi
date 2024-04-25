using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Application;


namespace WebApplication1.Controllers;

public class HomeController() : ControllerBase
{


    public IActionResult Index()
    {
        return Ok("ok");
    }

    public IActionResult Privacy()
    {
        return Ok();
    }
}