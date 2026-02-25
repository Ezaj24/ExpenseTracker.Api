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
    public async Task<ActionResult<List<Expense>>> GetAllAsync()
    {
        return await _expenseService.GetAllAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Expense>> PostAsync([FromBody]CreateExpenseDto dto)
    {
        var result = await _expenseService.CreateAsync(dto);

        return result;
    }
}