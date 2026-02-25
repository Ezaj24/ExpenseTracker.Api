using ExpenseTracker.Api.Data;
using ExpenseTracker.Api.Dtos;
using ExpenseTracker.Api.Models;
using ExpenseTracker.Api.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Api.Services.Implementation;

public class ExpenseService : IExpenseService
{
    private readonly AppDbContext _context;

    public ExpenseService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Expense>> GetAllAsync()
    {
        var expenses = await _context.Expenses.ToListAsync();
        return expenses;

    }

    public async Task<Expense> CreateAsync(CreateExpenseDto dto)
    {
        var result = new Expense()
        {
            
            Title = dto.Title,
            Amount = dto.Amount,
            Category = dto.Category,
            
        };
        
          _context.Expenses.Add(result);
        await _context.SaveChangesAsync();
        
        return result;
    }
}