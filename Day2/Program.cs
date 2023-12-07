// See https://aka.ms/new-console-template for more information

using Solutions;

Console.WriteLine("Paste you input bellow (ctrl+z) when complete");
var input = Console.In.ReadToEnd();

Console.WriteLine("Bag settings: ");
Console.Write("Red: ");
var red = int.Parse(Console.ReadLine());

Console.Write("Green: ");
var green = int.Parse(Console.ReadLine());

Console.Write("Blue: ");
var blue = int.Parse(Console.ReadLine());

var result = Day2.SumOfGamesPossible(input, new Day2.Bag(red, green, blue));
Console.WriteLine($"Result: {result}");