using ConsoleApp;
using ConsoleApp.Data;
using ConsoleApp.Models;
using ConsoleApp.Repositories;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

try
{
    var migrationService = new MigrationService();
    await migrationService.ApplyMigrationsAsync();
}
catch (MySqlException e)
{
    Console.WriteLine($"An error occured while trying to migrate the database: {e}");
    return;
}

if (args.Length != 2)
{
    Console.WriteLine("Please enter two arguments.");
    return;
}

var firstArgument = args[0];
var secondArgument = args[1];

if (string.IsNullOrWhiteSpace(firstArgument))
{
    Console.WriteLine("First argument cannot be empty.");
    return;
}

if (string.IsNullOrWhiteSpace(secondArgument))
{
    Console.WriteLine("Second argument cannot be empty.");
    return;
}

if (firstArgument.Length > Constants.MaxArgumentLength || secondArgument.Length > Constants.MaxArgumentLength)
{
    Console.WriteLine($"Arguments cannot be longer than {Constants.MaxArgumentLength} characters.");
    return;
}

try
{
    var result = firstArgument.Add(secondArgument);
    Console.WriteLine($"Result of combined arguments: {result}");
}
catch (Exception e) when (e is FormatException or OverflowException)
{
    Console.WriteLine("Could not successfully add the arguments together.");
    return;
}

var repository = new ArgumentPairsRepository();
var argumentPairToSave = new ArgumentPair { First = firstArgument, Second = secondArgument };

try
{
    await repository.AddAsync(argumentPairToSave);

    var allArgumentPairs = await repository.GetAllAsync();

    if (allArgumentPairs.Count == 0)
    {
        Console.WriteLine("No arguments saved in the database.");
        return;
    }

    Console.WriteLine("Saved arguments:");

    foreach (var pair in allArgumentPairs)
    {
        Console.WriteLine(pair);
    }
}
catch (Exception e) when (e is MySqlException or DbUpdateException)
{
    Console.WriteLine($"An exception occured while trying to access the database: {e}");
}
catch (Exception e)
{
    Console.WriteLine($"An exception occured: {e}");
}