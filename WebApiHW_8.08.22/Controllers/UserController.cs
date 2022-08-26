using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiHW_8._08._22.Interfaces.Service;
using WebApiHW_8._08._22.Repository.Models;

using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using WebApiHW_8._08._22.Services.Models;

namespace WebApiHW_8._08._22.Controllers;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _service;
    public UserController(IUserService service)
    {
        _service = service;
    }
    
    [HttpPost("auth")]
    [AllowAnonymous]
    public IActionResult Authorize([FromBody] TokenRequest req)
    {
        var result = _service.Authenticate(req.Username, req.Password);
        return Ok(result);
    }

    [HttpGet("get")]
    public IActionResult GetContracts()
    {
        var result = _service.GetAll();
        Task.WaitAll(result);
        return result.Status == TaskStatus.RanToCompletion ? Ok(result.Result) : BadRequest(result.Status);
    }

    [HttpGet("get/{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var result = _service.GetById(id);
        return result.Status != TaskStatus.Faulted ? Ok(result.Result) : BadRequest(result.Exception!.Message);
    }

    [HttpPost("register")]
    public IActionResult CreateNew([FromBody] User client)
    {
        var result = _service.Insert(client);
        return result.Status != TaskStatus.Faulted ? Ok(result.Result) : BadRequest(result.Exception!.Message);
    }

    [HttpPut("update/{id}")]
    public IActionResult UpdateContract([FromRoute] int id, [FromBody] User client)
    {
        var result = _service.UpdateOne(new User() { Id = id, Name = client.Name });
        return result.Status != TaskStatus.Faulted ? Ok(result.Result) : BadRequest(result.Exception!.Message);
    }

    [HttpDelete("delete/{id}")]
    public IActionResult DeleteById([FromRoute] int id)
    {
        var result = _service.DeleteById(id);
        return result.Status != TaskStatus.Faulted ? Ok(result.Result) : BadRequest(result.Exception!.Message);
    }
}
