using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiHW_8._08._22.Interfaces.Service;
using WebApiHW_8._08._22.Repository.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebApiHW_8._08._22.Controllers;

[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = "Bearer")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _service;
    public UserController(IUserService service)
    {
        _service = service;
    }

    [AllowAnonymous]
    [HttpPost("auth")]
    public IActionResult Auth([FromBody] AuthRequest areq)
    {
        var str = _service.Authenticate(areq.Login, areq.Password);
        return Ok(new AuthResponse() { Success = true, Token = str });
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
public class AuthRequest
{
    public string Login { get; set; }
    public string Password { get; set; }
}
public class AuthResponse
{
    public bool Success { get; set; }
    public string Token { get; set; }
}