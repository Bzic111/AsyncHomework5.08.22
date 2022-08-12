using Microsoft.AspNetCore.Mvc;
using WebApiHW_8._08._22.Interfaces;
using WebApiHW_8._08._22.Repository.Models;

namespace WebApiHW_8._08._22.Controllers;

[Route("api/invoices")]
[ApiController]
public class InvoicesController : ControllerBase
{
    private readonly IInvoiceHolder _holder;
    public InvoicesController(IInvoiceHolder holder)
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
    public IActionResult CreateNew([FromBody] Invoice invoice)
    {
        return Ok(_holder.Create(invoice));
    }
    [HttpPut("update/{id}")]
    public IActionResult UpdateContract([FromRoute] int id, [FromBody] Invoice invoice)
    {
        invoice.Id = id;
        return Ok(_holder.Update(invoice));
    }
    [HttpDelete("delete/{id}")]
    public IActionResult DeleteById([FromRoute] int id)
    {
        return Ok(_holder.DeleteById(id));
    }
}
