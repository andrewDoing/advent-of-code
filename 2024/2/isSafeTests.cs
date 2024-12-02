using Xunit;

namespace ReportAnalyzer.Tests
{
    public class ReportAnalyzerTests
    {
        [Theory]
        [InlineData(new int[] { 7, 6, 4, 2, 1 }, true)]
        [InlineData(new int[] { 1, 2, 7, 8, 9 }, false)]
        [InlineData(new int[] { 9, 7, 6, 2, 1 }, false)]
        [InlineData(new int[] { 1, 3, 2, 4, 5 }, true)]
        [InlineData(new int[] { 8, 6, 4, 4, 1 }, true)]
        [InlineData(new int[] { 1, 3, 6, 7, 9 }, true)]
        [InlineData(new int[] { 9, 1, 2, 3, 4 }, true)]
        public void TestExampleData(int[] report, bool expected)
        {
            var analyzer = new ReportAnalyzer();
            var result = analyzer.isSafe(report);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 7, 3, 4 }, 2, true)]
        [InlineData(new int[] { 7, 2, 3, 4 }, 0, true)]
        public void TestProblemDampener(int[] report, int indexToRemove, bool expected)
        {
            var analyzer = new ReportAnalyzer();
            var result = analyzer.ProblemDampener(report, indexToRemove);
            Assert.Equal(expected, result);
        }
    }
}