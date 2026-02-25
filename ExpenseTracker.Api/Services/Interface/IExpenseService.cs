using ExpenseTracker.Api.Dtos;
using ExpenseTracker.Api.Models;

namespace ExpenseTracker.Api.Services.Interface;

public interface IExpenseService
{
    Task<Expense> CreateAsync(CreateExpenseDto dto);

    Task<List<Expense>> GetAllAsync();
    
    Task<Expense?> GetByIdAsync(int id);

    Task<bool> DeleteAsync(int id);
    
    Task<Expense?> UpdateAsync(int id , CreateExpenseDto dto);
}