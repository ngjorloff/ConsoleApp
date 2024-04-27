using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Data;

public sealed class MigrationService
{
    public async Task ApplyMigrationsAsync()
    {
        await using var dbContext = new AppDbContext();
        await dbContext.Database.MigrateAsync();
    }
}