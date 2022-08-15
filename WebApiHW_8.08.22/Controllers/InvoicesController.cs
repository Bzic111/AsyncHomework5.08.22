﻿using Microsoft.AspNetCore.Mvc;
using WebApiHW_8._08._22.Interfaces;
using WebApiHW_8._08._22.Repository.Models;

namespace WebApiHW_8._08._22.Controllers;

[Route("api/invoices")]
[ApiController]
public class InvoicesController : ControllerBase
{
    private readonly IInvoiceService _service;
    public InvoicesController(IInvoiceService service)
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
    public IActionResult CreateNew([FromBody] Invoice employer)
    {
        var result = _service.Insert(employer);
        return result.Status != TaskStatus.Faulted ? Ok(result.Result) : BadRequest(result.Exception!.Message);
    }
    [HttpPut("update/{id}")]
    public IActionResult UpdateContract([FromRoute] int id, [FromBody] Invoice employer)
    {
        var result = _service.UpdateOne(new Invoice() { Id = id });
        return result.Status != TaskStatus.Faulted ? Ok(result.Result) : BadRequest(result.Exception!.Message);
    }
    [HttpDelete("delete/{id}")]
    public IActionResult DeleteById([FromRoute] int id)
    {
        var result = _service.DeleteById(id);
        return result.Status != TaskStatus.Faulted ? Ok(result.Result) : BadRequest(result.Exception!.Message);
    }
}
