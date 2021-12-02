public class DayOne: Day {
    public override void SolvePartOne() 
    {
        var rawInput = Utils.readInput(1);
        var input = formatInput(rawInput);
        var count = 0;
        for(var i = 1; i < input.Count; i++)
        {
            if(input[i] > input[i-1]) count++;
        }

        Console.WriteLine(count);
    }

    public override void SolvePartTwo()
    {
        var count = 0;
        var rawInput = Utils.readInput(1);
        var input = formatInput(rawInput);
        for(var i = 1; i < input.Count; i++)
        {
            var current = GetSlidingSum(input, i);
            var previous = GetSlidingSum(input, i-1);
            if(current > previous) count++;
        }
        Console.WriteLine(count);   
    }

    private int GetSlidingSum(List<int> input, int index) 
    {
        if((index + 2) > input.Count - 1) return -1;
        return input[index] + input[index+1] + input[index+2];

    }

    private static List<int> formatInput(List<string> input)
    {
        return input.Select(i => Int32.Parse(i)).ToList();
    }
}