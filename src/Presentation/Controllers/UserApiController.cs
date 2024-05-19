using System.Diagnostics;
using Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Presentation.Controllers;

[Route("api")]
public class UserApiController(IMediator mediator) : ControllerBase
{
    [HttpGet("getbyid/{id:long}")]
    public async Task<IActionResult> GetUserById(long id)
    {
        var request = new GetUser(id);
        var resp = await mediator.Send(request);
        return resp is null ? NotFound("user with selected id could not be found!") :  Ok(resp);
    }

    [HttpGet("getbyname")]
    public async Task<IActionResult> GetByName([FromQuery] string name, [FromQuery] string surname = "")
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