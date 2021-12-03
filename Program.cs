internal class CommandLine
{
    private static void Main(string[] args)
    {
        var dayNo = int.Parse(args[0]);
        var partNo = int.Parse(args[1]);
        Day day = new DayOne();
        switch (dayNo)
        {
            case 1:
                day = new DayOne();
                break;
            case 2:
                day = new DayTwo();
                break;
        }

        day.Solve(partNo);
    }
}