using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiHW_8._08._22.Entity;
using WebApiHW_8._08._22.Holders;
using WebApiHW_8._08._22.Interfaces;

namespace WebApiHW_8._08._22.Controllers;

[Route("api/contracts")]
[ApiController]
public class ContractsController : ControllerBase
{
    private readonly IContractHolder _holder;
    public ContractsController(IContractHolder holder)
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
    public IActionResult CreateNew([FromBody] Contract contract)
    {
        return Ok(_holder.Create(contract));
    }
    [HttpPut("update/{id}")]
    public IActionResult UpdateContract([FromRoute] int id, [FromBody] Contract contract)
    {
        contract.Id = id;
        return Ok(_holder.Update(contract));
    }
    [HttpDelete("delete/{id}")]
    public IActionResult DeleteById([FromRoute] int id)
    {
        return Ok(_holder.DeleteById(id));
    }
}
