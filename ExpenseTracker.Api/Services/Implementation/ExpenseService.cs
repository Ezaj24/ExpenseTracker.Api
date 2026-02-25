using ExpenseTracker.Api.Data;
using ExpenseTracker.Api.Dtos;
using ExpenseTracker.Api.Models;
using ExpenseTracker.Api.Services.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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

    public async Task<Expense?> GetByIdAsync(int id)
    {
        var search = await _context.Expenses.FirstOrDefaultAsync(x => x.Id == id);
        if (search == null)
        {
            return null;
        }
        
        return search;
    }

    public async Task<Expense?> UpdateAsync(int id, CreateExpenseDto dto)
    {
        var expense = await _context.Expenses.FirstOrDefaultAsync(x => x.Id == id);
        if (expense == null)
        {
            return null;;
        }


        expense.Title = dto.Title;
        expense.Amount = dto.Amount;
        expense.Category = dto.Category;
        
        
        
        await _context.SaveChangesAsync();
        
        return expense;

    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        var search = await _context.Expenses.FirstOrDefaultAsync(x => x.Id == id);
        if(search == null)
        {
            return false;
        }
        
        _context.Expenses.Remove(search);
        await _context.SaveChangesAsync();

        return true;
    }
}