namespace ReportAnalyzer;

partial class Program
{
    static void Main(string[] args)
    {
        string path = @"./input.txt";
        ReportAnalyzer analyzer = new ReportAnalyzer();
        List<int[]> reports = analyzer.LoadReports(path);
        Console.WriteLine("Number of safe reports: " + analyzer.numSafe(reports));
    }
}