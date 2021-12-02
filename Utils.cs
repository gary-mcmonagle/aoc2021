public class Utils {
    public static List<string> readInput(int dayNo) {
        var lines = File.ReadAllLines($"input/Day{dayNo}.txt");
        return lines.ToList();
    }
}