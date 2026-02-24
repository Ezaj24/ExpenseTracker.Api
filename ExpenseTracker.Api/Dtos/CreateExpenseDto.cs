using ExpenseTracker.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Api.Dtos;

public class CreateExpenseDto
{
    
    public string Title { get; set; } = string.Empty; 
    
    [Required]
    [Range(0, double.MaxValue)]
    public double Amount { get; set; } 
    
    [Required]
    public CategoryType Category { get; set; } 
    
    
    
}