using NumericWordsConversion;

internal class CommandLine
{
    private static void Main(string[] args)
    {
        NumericWordsConverter converter = new();
        var dayNo = int.Parse(args[0]);
        var dayWord = converter.ToWords(dayNo);
        string objectToInstantiate = $"Day{dayWord}";
        var objectType = Type.GetType(objectToInstantiate);
        dynamic instantiatedObject = Activator.CreateInstance(objectType);
        var partNo = int.Parse(args[1]);
        instantiatedObject.Solve(partNo);
    }
}