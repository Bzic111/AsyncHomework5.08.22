using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiHW_8._08._22.Interfaces.Service;
using WebApiHW_8._08._22.Repository.Models;

namespace WebApiHW_8._08._22.Controllers;

[Route("api/contracts")]
[ApiController]
public class ContractsController : ControllerBase
{
    private readonly IContractService _service;
    public ContractsController(IContractService service)
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
    public IActionResult CreateNew([FromBody] Contract contract)
    {
        var result = _service.Insert(contract);
        return result.Status != TaskStatus.Faulted ? Ok(result.Result) : BadRequest(result.Exception!.Message);
    }
    [HttpPut("update/{id}")]
    public IActionResult UpdateContract([FromRoute] int id, [FromBody] Contract contract)
    {
        var result = _service.UpdateOne(new Contract() { Id = id });
        return result.Status != TaskStatus.Faulted ? Ok(result.Result) : BadRequest(result.Exception!.Message);
    }
    [HttpDelete("delete/{id}")]
    public IActionResult DeleteById([FromRoute] int id)
    {
        var result = _service.DeleteById(id);
        return result.Status != TaskStatus.Faulted ? Ok(result.Result) : BadRequest(result.Exception!.Message);
    }
}
