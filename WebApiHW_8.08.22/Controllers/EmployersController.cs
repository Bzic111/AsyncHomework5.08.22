using Microsoft.AspNetCore.Mvc;
using WebApiHW_8._08._22.Entity;
using WebApiHW_8._08._22.Interfaces;

namespace WebApiHW_8._08._22.Controllers;

[Route("api/employers")]
[ApiController]
public class EmployersController : ControllerBase
{
    private readonly IEmployerHolder _holder;
    public EmployersController(IEmployerHolder holder)
    {
        _holder = holder;
    }

    [HttpGet("get")]
    public IActionResult GetContracts()
    {
        return Ok(_holder.GetAll());
    }

    [HttpGet("get/{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        return Ok(_holder.GetById(id));
    }
    [HttpPost("register")]
    public IActionResult CreateNew([FromBody] Employer employer)
    {
        return Ok(_holder.Create(employer));
    }
    [HttpPut("update/{id}")]
    public IActionResult UpdateContract([FromRoute] int id, [FromBody] Employer employer)
    {
        employer.Id = id;
        return Ok(_holder.Update(employer));
    }
    [HttpDelete("delete/{id}")]
    public IActionResult DeleteById([FromRoute] int id)
    {
        return Ok(_holder.DeleteById(id));
    }
}