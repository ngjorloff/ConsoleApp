namespace ConsoleApp.Tests;

public sealed class ArgumentExtensionsTests
{
    [Theory]
    [InlineData("0", "0", 0)]
    [InlineData("1", "1", 2)]
    [InlineData("-2", "1", -1)]
    [InlineData("a", "b", "ab")]
    [InlineData("0.1", "0.9", 1f)]
    [InlineData("1.5", "-0.5", 1f)]
    public void ShouldAddTwoArguments(string firstArgument, string secondArgument, object expected)
    {
        var actual = firstArgument.Add(secondArgument);
        Assert.Equal(expected, actual);
    }
    
    [Theory] 
    [InlineData(null, "1")]
    [InlineData("", "1")]
    [InlineData("1", null)]
    [InlineData("1", "")]
    public void ShouldThrowExceptionWhenArgumentsAreEmptyOrNull(string? firstArgument, string secondArgument)
    {
        Assert.Throws<ArgumentException>(() => firstArgument!.Add(secondArgument));
    }
    
    [Theory] 
    [InlineData("999999999999999999999", "999999999999999999999")]
    public void ShouldThrowExceptionWhenNumericArgumentsAreTooLarge(string firstArgument, string secondArgument)
    {
        Assert.Throws<OverflowException>(() => firstArgument.Add(secondArgument));
    }
}