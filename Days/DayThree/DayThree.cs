public class DayThree : Day
{
    public override void SolvePartOne()
    {
        var rawInput = Utils.readInput(3);

        var diag = new SubmarineDiagnosticReportParser(parseInput(rawInput));

        var gamme = Convert.ToInt32(diag.Gamma(), 2);
        var epson = Convert.ToInt32(diag.Epson(), 2);
        Console.WriteLine(epson * gamme);
    }

    public override void SolvePartTwo()
    {
        var rawInput = Utils.readInput(3);
        var ls = new LifeSupport(parseInput(rawInput));
        var gamme = Convert.ToInt32(ls.GetOxegenGeneratorRating(), 2);
        var epson = Convert.ToInt32(ls.GetCo2GeneratorRating(), 2);
        Console.WriteLine(epson * gamme);
    }

    private List<List<int>> parseInput(List<string> input)
    {
        var split = input.Select(x => x.ToCharArray().ToList());
        Func<List<char>, List<int>> makeInts = l => l.Select(x => Int32.Parse(x.ToString())).ToList();
        return split.Select(x => makeInts(x.ToList())).ToList();
    }
}

internal class SubmarineDiagnosticReportParser
{
    private List<List<int>> rawReport;

    public SubmarineDiagnosticReportParser(List<List<int>> rawReport)
    {
        this.rawReport = rawReport;
    }

    public string Gamma()
    {
        var str = "";
        for (var i = 0; i < rawReport[0].Count; i++) str += GetGammeRate(i);
        return str;
    }

    public string Epson()
    {
        var str = "";
        for (var i = 0; i < rawReport[0].Count; i++) str += GetEsponRate(i);
        return str;
    }

    public char GetGammeRate(int index)
    {
        var col = rawReport.Select(x => x[index]).ToList();
        var oneCount = col.Where(x => x == 1).ToList().Count;
        return oneCount >= col.Count / 2 ? '1' : '0';
    }

    public char GetEsponRate(int index)
    {
        var col = rawReport.Select(x => x[index]).ToList();
        var oneCount = col.Where(x => x == 1).ToList().Count;
        return oneCount >= col.Count / 2 ? '0' : '1';
    }
}

internal class LifeSupport
{
    private readonly List<List<int>> rawReport;

    public LifeSupport(List<List<int>> rawReport)
    {
        this.rawReport = rawReport;
    }

    public string GetOxegenGeneratorRating()
    {
        var str = "";
        var elig = rawReport;
        var index = 0;
        do
        {
            var charToMatch = getCharToMatch(elig, index, true);
            str += charToMatch;
            elig = getEligableRows(elig, charToMatch, index, true);
            index++;
        } while (elig.Count > 1);

        return fillString(elig, str);
    }

    public string GetCo2GeneratorRating()
    {
        var str = "";
        var elig = rawReport;
        var index = 0;
        do
        {
            var charToMatch = getCharToMatch(elig, index, false);
            str += charToMatch;
            elig = getEligableRows(elig, charToMatch, index, false);
            index++;
        } while (elig.Count > 1);

        return fillString(elig, str);
    }

    private string fillString(List<List<int>> report, string str)
    {
        var targetR = report[report.Count - 1];
        while (str.Length < targetR.Count) str += targetR[str.Length];
        return str;
    }

    private char getCharToMatch(List<List<int>> report, int bitIndex, Boolean isOxygen)
    {
        var col = report.Select(bin => bin[bitIndex]);
        var zeroCount = col.Where(x => x == 0).ToList().Count;
        var oneCount = col.Where(x => x == 1).ToList().Count;

        if (zeroCount > oneCount) return isOxygen ? '0' : '1';
        if (oneCount > zeroCount) return isOxygen ? '1' : '0';
        return isOxygen ? '1' : '0';
    }

    private List<List<int>> getEligableRows(List<List<int>> report, char charToMatch, int bitIndex, Boolean isOxygen)
    {
        var eligable = new List<List<int>>();
        foreach (var list in report)
            if (list[bitIndex].ToString()[0] == charToMatch)
                eligable.Add(list);
        return eligable;
    }
}