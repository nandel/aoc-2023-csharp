using Shouldly;

namespace UnitTests.Day1;

public class Day1Tests
{
    [Fact]
    public void SumOfCalibrationValues_Using1stExample_ShouldBe142()
    {
        // arrange
        var subject = new Solutions.Day1();
        var file = File.OpenText("Day1/1st-example.txt");
        
        // act
        var result = Solutions.Day1.SumOfCalibrationValues(file);
        
        // assert
        result.ShouldBe(142);
    }
    
    [Fact]
    public void SumOfCalibrationValues_Using2ndExample_ShouldBe281()
    {
        // arrange
        var subject = new Solutions.Day1();
        var file = File.OpenText("Day1/2nd-example.txt");
        
        // act
        var result = Solutions.Day1.SumOfCalibrationValues(file);
        
        // assert
        result.ShouldBe(281);
    }
}