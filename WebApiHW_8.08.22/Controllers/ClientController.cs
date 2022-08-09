using Microsoft.AspNetCore.Mvc;
using WebApiHW_8._08._22.Entity;
using WebApiHW_8._08._22.Interfaces;

namespace WebApiHW_8._08._22.Controllers;

[Route("api/customers")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IClientHolder _holder;
    public ClientController(IClientHolder holder)
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
    public IActionResult CreateNew([FromBody] Client client)
    {
        return Ok(_holder.Create(client));
    }
    [HttpPut("update/{id}")]
    public IActionResult UpdateContract([FromRoute] int id, [FromBody] Client client)
    {
        client.Id = id;
        return Ok(_holder.Update(client));
    }
    [HttpDelete("delete/{id}")]
    public IActionResult DeleteById([FromRoute] int id)
    {
        return Ok(_holder.DeleteById(id));
    }
}
