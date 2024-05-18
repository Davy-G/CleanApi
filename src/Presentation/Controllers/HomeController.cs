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

    [HttpGet("getbyname/{name} {surname}")]
    //TODO add search by queries
    public async Task<IActionResult> GetByName(string name, string surname = "")
    {
        var request = new GetUserByName(name, surname);
        var resp = await mediator.Send(request);
        return resp is null ? NotFound("user with selected name or surname could not be found!") :  Ok(resp);
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