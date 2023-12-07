using Shouldly;

namespace UnitTests.Day1;

public class Day1Tests
{
    [Theory]
    [InlineData("1st-example.txt", 142)]
    [InlineData("2nd-example.txt", 281)]
    public void SumOfCalibrationValues_UsingExamples(string exampleFile, int expectedResult)
    {
        // arrange
        var file = File.OpenText($"Day1/{exampleFile}");
        
        // act
        var result = Solutions.Day1.SumOfCalibrationValues(file);
        
        // assert
        result.ShouldBe(expectedResult);
    }
}