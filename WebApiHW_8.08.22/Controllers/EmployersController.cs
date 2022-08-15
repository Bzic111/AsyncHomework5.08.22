using Microsoft.AspNetCore.Mvc;
using WebApiHW_8._08._22.Repository.Models;
using WebApiHW_8._08._22.Interfaces;

namespace WebApiHW_8._08._22.Controllers;

[Route("api/employers")]
[ApiController]
public class EmployersController : ControllerBase
{
    private readonly IEmployerService _service;
    public EmployersController(IEmployerService service)
    {
        _service = service;
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
    public IActionResult CreateNew([FromBody] Employer employer)
    {
        var result = _service.Insert(employer);
        return result.Status != TaskStatus.Faulted ? Ok(result.Result) : BadRequest(result.Exception!.Message);
    }

    [HttpPut("update/{id}")]
    public IActionResult UpdateContract([FromRoute] int id, [FromBody] Employer employer)
    {
        var result = _service.UpdateOne(new Employer() { Id = id, Name = employer.Name });
        return result.Status != TaskStatus.Faulted ? Ok(result.Result) : BadRequest(result.Exception!.Message);
    }

    [HttpDelete("delete/{id}")]
    public IActionResult DeleteById([FromRoute] int id)
    {
        var result = _service.DeleteById(id);
        return result.Status != TaskStatus.Faulted ? Ok(result.Result) : BadRequest(result.Exception!.Message);
    }
}