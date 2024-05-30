using System.Diagnostics;
using Application.Users.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Presentation.Controllers;

[Route("api")]
public class UserApiController(IMediator mediator) : ControllerBase
{
    [HttpGet("getbyid/{id:long}")]
    public async Task<IActionResult> GetUserById(long id)
    {
        var request = new GetPerson(id);
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

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        
        if (model is null || string.IsNullOrEmpty(model.password) ||
            string.IsNullOrEmpty(model.uname))
        {
            return BadRequest("invalid user data");
        }
        var request = new Register(model.uname, model.password);
        Console.WriteLine(model.uname);
        var resp = await mediator.Send(request);
        return Ok(resp);
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