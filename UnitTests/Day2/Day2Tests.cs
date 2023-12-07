using Shouldly;

namespace UnitTests.Day2;

public class Day2Tests
{
    [Fact]
    public void SumOfGamesPossible_Following1stExample_ShouldReturn8()
    {
        // arrange
        var file = File.OpenText($"Day2/1st-example.txt");
        
        // act
        var result = Solutions.Day2.SumOfGamesPossible(file, new Solutions.Day2.Bag(Red:12, Green: 13, Blue: 14));
        
        // assert
        result.ShouldBe(8);
    }
}