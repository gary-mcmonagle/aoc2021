public class DayTwo : Day
{
    public override void SolvePartOne()
    {
        var rawInput = Utils.readInput(2);
        Submarine sub = new();
        foreach (var inp in rawInput) sub.Move(new SubmarineInstruction(inp));
        Console.WriteLine(sub.Depth * sub.HorizontalPosition);
    }

    public override void SolvePartTwo()
    {
        var rawInput = Utils.readInput(2);
        FighterSubmarine sub = new();
        foreach (var inp in rawInput) sub.Move(new SubmarineInstruction(inp));
        Console.WriteLine(sub.Depth * sub.HorizontalPosition);
    }
}


internal enum Direction
{
    Forward = 0,
    Up = 1,
    Down = 2
}

internal class Submarine
{
    public int Depth { get; set; }
    public int HorizontalPosition { get; set; }

    public virtual void Move(SubmarineInstruction instruction)
    {
        if (instruction.Direction == Direction.Up)
            Depth -= instruction.Amount;
        else if (instruction.Direction == Direction.Down)
            Depth += instruction.Amount;
        else
            HorizontalPosition += instruction.Amount;
    }
}

internal class SubmarineInstruction
{
    public SubmarineInstruction(string input)
    {
        var splitInput = input.Split(' ');
        switch (splitInput[0])
        {
            case "up":
                Direction = Direction.Up;
                break;
            case "down":
                Direction = Direction.Down;
                break;
            case "forward":
                Direction = Direction.Forward;
                break;
        }

        Amount = Int32.Parse(splitInput[1]);
    }

    public Direction Direction { get; }
    public int Amount { get; }
}

internal class FighterSubmarine : Submarine
{
    public int Aim { get; set; }

    public override void Move(SubmarineInstruction instruction)
    {
        if (instruction.Direction == Direction.Up)
        {
            Aim -= instruction.Amount;
        }
        else if (instruction.Direction == Direction.Down)
        {
            Aim += instruction.Amount;
        }
        else
        {
            HorizontalPosition += instruction.Amount;
            Depth += Aim * instruction.Amount;
        }
    }
}