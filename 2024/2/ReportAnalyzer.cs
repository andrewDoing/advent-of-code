namespace ReportAnalyzer;

public class ReportAnalyzer
{
    public List<int[]> LoadReports(string path)
    {
        var lines = File.ReadAllLines(path);
        List<int[]> reports = new List<int[]>();
        foreach (string line in lines)
        {
            string[] values = line.Split(" ");
            int[] ints = Array.ConvertAll(values, int.Parse);
            reports.Add(ints);
        }
        return reports;
    }

    public bool isSafe(int[] report, bool dampenProblems = true)
    {
        bool? trend = null;

        for (int i = 0; i < report.Length - 1; i++)
        {
            int difference = report[i] - report[i + 1];
            if (i == 0)
            {
                trend = difference >= 0;
            }
            if (difference == 0)
            {
                return dampenProblems ? ProblemDampener(report, i) : false;
            }
            if (Math.Abs(difference) > 3)
            {
                return dampenProblems ? ProblemDampener(report, i) : false;
            }
            bool currentTrend = difference > 0;
            if (currentTrend != trend)
            {
                // remove i because its the problem?
                // this seems more complex than previously understood. maybe need to see 3 trends to know which one to remove.
                return dampenProblems ? ProblemDampener(report, i) : false;
            }
        }
        return true;
    }

    public bool ProblemDampener(int[] report, int indexToRemove)
    {
        var newReport = new int[report.Length - 1];
        // first try removing the first element
        newReport = report.Skip(1).ToArray();
        if (isSafe(newReport, false))
        {
            return true;
        }

        // try to remove the element at indexToRemove
        newReport = report.Take(indexToRemove).Concat(report.Skip(indexToRemove + 1)).ToArray();

        if (isSafe(newReport, false)) {
            return true;
        }

        // try to remove indexToRemove + 1
        newReport = report.Take(indexToRemove + 1).Concat(report.Skip(indexToRemove + 2)).ToArray();

        if (isSafe(newReport, false)) {
            return true;
        }
        return false;
    }

    public int numSafe(List<int[]> reports)
    {
        int numSafe = 0;
        foreach (int[] report in reports)
        {
            if (isSafe(report))
            {
                numSafe++;
            }
        }
        return numSafe;
    }
}