public class DayTwo : Day {
    public override void SolvePartOne()
    {
       var rawInput = Utils.readInput(2);
       Submarine sub = new Submarine();
       foreach(var inp in rawInput) 
       {
           sub.Move(new SubmarineInstruction(inp));
       }
       Console.WriteLine(sub.Depth * sub.HorizontalPosition);
    }

    public override void SolvePartTwo() {
       var rawInput = Utils.readInput(2);
       FighterSubmarine sub = new FighterSubmarine();
       foreach(var inp in rawInput) 
       {
           sub.Move(new SubmarineInstruction(inp));
       }
        Console.WriteLine(sub.Depth * sub.HorizontalPosition);


    }

}


enum Direction {
    Forward = 0,
    Up = 1,
    Down = 2
}

class Submarine {

    public int Depth {get; set;}
    public int HorizontalPosition {get; set;}

    public virtual void Move(SubmarineInstruction instruction)
    {
        if(instruction.Direction == Direction.Up) {
            Depth -= instruction.Amount;
        }
        else if(instruction.Direction == Direction.Down) {
            Depth += instruction.Amount;
        }
        else {
            HorizontalPosition += instruction.Amount;
        }
    }
}
class SubmarineInstruction {
    public SubmarineInstruction(string input) 
    {
        var splitInput = input.Split(' ');
        switch(splitInput[0]) {
            case "up": this.Direction = Direction.Up;
            break;
            case "down": this.Direction = Direction.Down;
            break;
            case "forward": this.Direction = Direction.Forward;
            break;
        }
        this.Amount = Int32.Parse(splitInput[1]);
    }

    public Direction Direction { get; }
    public int Amount { get; }
}

class FighterSubmarine: Submarine {
    public int Aim { get; set; }
    public override void Move(SubmarineInstruction instruction) {
        if(instruction.Direction == Direction.Up) {
            Aim -= instruction.Amount;
        }
        else if(instruction.Direction == Direction.Down) {
            Aim += instruction.Amount;
        }
        else {
            HorizontalPosition += instruction.Amount;
            Depth += Aim * instruction.Amount;
        }
        
    }
    
}