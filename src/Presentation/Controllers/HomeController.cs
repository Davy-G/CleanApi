using System.Diagnostics;
using Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;
[Route("api")]
public class HomeController(IMediator mediator) : ControllerBase
{
    [HttpGet("getbyid/{id:long}")]
    public async Task<IActionResult> GetUserById(long id)
    {
        var request = new GetUserById(id);
        var resp = await mediator.Send(request);
        return resp is null ? NotFound("user with selected id could not be found!") :  Ok(resp);
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