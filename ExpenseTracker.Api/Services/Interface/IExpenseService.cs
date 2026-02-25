using ExpenseTracker.Api.Dtos;
using ExpenseTracker.Api.Models;

namespace ExpenseTracker.Api.Services.Interface;

public interface IExpenseService
{
    Task<Expense> CreateAsync(CreateExpenseDto dto);

    Task<List<Expense>> GetAllAsync();
}