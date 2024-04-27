using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Models;

public sealed class ArgumentPair
{
    [Key] 
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [MaxLength(Constants.MaxArgumentLength)]
    public required string First { get; init; } = "";
    
    [MaxLength(Constants.MaxArgumentLength)]
    public required string Second { get; init; } = "";

    public override string ToString()
    {
        return $"First argument: {First}, second argument: {Second}";
    }
}