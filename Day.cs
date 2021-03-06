public abstract class Day
{
    public abstract void SolvePartOne();
    public abstract void SolvePartTwo();

    public virtual void Solve(int partNo)
    {
        if (partNo == 1) SolvePartOne();
        else
            SolvePartTwo();
    }
}