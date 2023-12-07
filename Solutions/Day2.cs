namespace Solutions;

public static class Day2
{
    public static int SumOfGamesPossible(string input, Bag bag)
    {
        var total = 0;
        var lines = input.Split(Environment.NewLine);
        foreach (var gameData in lines)
        {
            if (string.IsNullOrWhiteSpace(gameData))
            {
                continue;
            }
            
            var game = new Game(gameData);

            if (game.RequiredBag.Red <= bag.Red 
                && game.RequiredBag.Green <= bag.Green 
                && game.RequiredBag.Blue <= bag.Blue)
            {
                total += game.Id;    
            }
        }
        
        return total;
    }
    
    public static int SumOfGamesPossible(StreamReader input, Bag bag)
    {
        var total = 0;
        while (!input.EndOfStream)
        {
            var gameData = input.ReadLine();
            if (string.IsNullOrWhiteSpace(gameData))
            {
                continue;
            }
            
            var game = new Game(gameData);

            if (game.RequiredBag.Red <= bag.Red 
                && game.RequiredBag.Green <= bag.Green 
                && game.RequiredBag.Blue <= bag.Blue)
            {
                total += game.Id;    
            }
        }
        
        return total;
    }

    public record Bag(int Red, int Green, int Blue)
    {
        public int Red { get; set; } = Red;
        public int Green { get; set; } = Green;
        public int Blue { get; set; } = Blue;
    };

    private class Game
    {
        public const int GAME_KEYWORD_LENGTH = 5; // "GAME "
        
        public int Id { get; }
        public Bag RequiredBag { get; } = new Bag(0, 0, 0);
        public IList<Round> Rounds { get; } = new List<Round>();

        public Game(string data)
        {
            var gameAndRoundSplitIndex = data.IndexOf(":", StringComparison.InvariantCultureIgnoreCase);

            var idAsString = data.Substring(GAME_KEYWORD_LENGTH, gameAndRoundSplitIndex - GAME_KEYWORD_LENGTH);
            Id = int.Parse(idAsString);

            var roundsData = data.Substring(gameAndRoundSplitIndex + 1).Split(';');
            foreach (var roundData in roundsData)
            {
                var round = new Round(roundData);
                Rounds.Add(round);
            }

            RequiredBag.Red = Rounds.Select(x => x.Red).Max();
            RequiredBag.Green = Rounds.Select(x => x.Green).Max();
            RequiredBag.Blue = Rounds.Select(x => x.Blue).Max();
        }
    }

    private class Round
    {
        public int Red { get; }
        public int Green { get; }
        public int Blue { get; set; }

        public Round(string data)
        {
            var segments = data.Split(',');
            foreach (var node in segments)
            {
                var trimedNode = node.Trim();
                var nodeSplit = trimedNode.IndexOf(' ');
                
                var numberAsString = trimedNode.Substring(0, nodeSplit);
                var number = int.Parse(numberAsString);
                
                var color = trimedNode.Substring(nodeSplit + 1);

                switch (color)
                {
                    case "red":
                        Red = number;
                        break;
                    
                    case "green":
                        Green = number;
                        break;
                    
                    case "blue":
                        Blue = number;
                        break;
                }
            }
        }
    }
}