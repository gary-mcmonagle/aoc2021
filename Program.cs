using System;

class CommandLine
{
    static void Main(string[] args)
    {
        var dayNo = Int32.Parse(args[0]);
        var partNo = Int32.Parse(args[1]);
        Day day = new DayOne();
        switch(dayNo) {
            case 1: day = new DayOne();
                break;
            case 2: day = new DayTwo();
                break;
        }
        day.Solve(partNo);

    }
}