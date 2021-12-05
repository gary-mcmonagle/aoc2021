public class DayFour : Day
{
    public override void SolvePartOne()
    {
        var rawInput = Utils.readInput(4);
        var numbers = getInputNumbers();
        var boards = getInputBoards();
        foreach (var num in numbers)
        foreach (var board in boards)
            if (board.CheckBingo(num))
            {
                Console.WriteLine(board.GetUnmarkedNumberTotal() * num);
                return;
            }
    }

    public override void SolvePartTwo()
    {
        var rawInput = Utils.readInput(4);
        var numbers = getInputNumbers();
        var boards = getInputBoards();
        foreach (var num in numbers)
        foreach (var board in boards)
            if (!board.Won)
                if (board.CheckBingo(num))
                    Console.WriteLine(board.GetUnmarkedNumberTotal() * num);
    }

    private List<int> getInputNumbers()
    {
        var rawInput = Utils.readInput(4);
        return rawInput[0].Split(',').Select(Int32.Parse).ToList();
    }

    private List<BingoBoard> getInputBoards()
    {
        var rawInput = Utils.readInput(4);

        var startIndex = 2;
        var boardLength = 5;
        var boards = new List<BingoBoard>();

        while (startIndex < rawInput.Count)
        {
            var rows = new List<List<int>>();
            for (var i = startIndex; i < startIndex + boardLength; i++)
            {
                var split = rawInput[i].Split();
                rows.Add(rawInput[i].Split(null)
                    .Where(x => x != null && x != string.Empty)
                    .Select(Int32.Parse).ToList());
            }

            boards.Add(new BingoBoard(rows));
            startIndex = startIndex + boardLength + 1;
        }

        Console.WriteLine(boards.Count);
        return boards;
    }
}

internal class BingoBoard
{
    private readonly List<BingoRow> cols = new List<BingoRow>();
    private readonly List<BingoRow> rows;


    public BingoBoard(List<List<int>> rows)
    {
        this.rows = rows.Select(r => new BingoRow(r)).ToList();
        for (var i = 0; i < rows.Count; i++)
        {
            var col = rows.Select(r => r[i]).ToList();
            cols.Add(new BingoRow(col));
        }
    }

    public bool Won { get; set; }

    public bool CheckBingo(int number)
    {
        var rowBingo = false;
        foreach (var row in rows)
            if (row.CheckBingo(number))
                rowBingo = true;
        var colBingo = false;
        foreach (var col in cols)
            if (col.CheckBingo(number))
                colBingo = true;

        Won = rowBingo || colBingo;
        return rowBingo || colBingo;
    }

    public int GetUnmarkedNumberTotal()
    {
        return rows.Select(r => r.GetUnmarkedNumberTotal()).Sum();
    }
}

internal class BingoRow
{
    private List<int> gotNumbers = new List<int>();
    private List<int> numbers;

    public BingoRow(List<int> numbers)
    {
        this.numbers = numbers;
    }

    public bool CheckBingo(int num)
    {
        if (numbers.Contains(num)) gotNumbers.Add(num);
        return numbers.Count == gotNumbers.Count;
    }

    public int GetUnmarkedNumberTotal()
    {
        var count = 0;
        foreach (var no in numbers)
            count += gotNumbers.Contains(no) ? 0 : no;
        return count;
    }
}