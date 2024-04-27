using ConsoleApp.Data;
using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Repositories;

public sealed class ArgumentPairsRepository
{
    public async Task<List<ArgumentPair>> GetAllAsync()
    {
        await using var context = new AppDbContext();
        return await context.ArgumentPairs.ToListAsync();
    }
    
    public async Task AddAsync(ArgumentPair argumentPair)
    {
        await using var context = new AppDbContext();
        context.ArgumentPairs.Add(argumentPair);
        await context.SaveChangesAsync();
    }
}