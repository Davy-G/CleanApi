using System.Diagnostics;
using Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;
[Route("api")]
public class HomeController(IMediator mediator) : ControllerBase
{
    [HttpGet("getbyid")]
    public async Task<IActionResult> Index()
    {
        var request = new GetUserById(270);
        var Response = await mediator.Send(request);
        return Ok(Response);
    }

    // public IActionResult Privacy()
    // {
    //     return Ok();
    // }

//     [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//     public IActionResult Error()
//     {
//     }
// }
}