using ExpenseTracker.Api.Services.Interface;
using ExpenseTracker.Api.Dtos;
using ExpenseTracker.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ExpensesController : ControllerBase
{
    private readonly IExpenseService _expenseService;

    public ExpensesController(IExpenseService expenseService)
    {
        _expenseService = expenseService;
    }


    [HttpGet]
    public async Task<ActionResult<List<Expense>>> GetAll()
    {
        return await _expenseService.GetAllAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Expense>> Post([FromBody]CreateExpenseDto dto)
    {
        var result = await _expenseService.CreateAsync(dto);

        return result;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Expense?>> GetById(int id)
    {
        var result = await _expenseService.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Expense?>> Update(int id, [FromBody] CreateExpenseDto dto)
    {
        var result = await _expenseService.UpdateAsync(id, dto);
        if(result == null)
        {
            return NotFound();
        }
        
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _expenseService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }

        
        return NoContent();
    } 

    
}