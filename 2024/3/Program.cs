using System.Text.RegularExpressions;

var text = File.ReadAllText(@"./input.txt");

Regex regex = new(@"mul\((\d{1,3}),(\d{1,3})\)|(do\(\))|(don't\(\))", RegexOptions.Compiled);

var matches = regex.Matches(text);

var sum = 0;
bool doStuff = true;
foreach (Match match in matches)
{
    Console.WriteLine(match.Value);

    if (match.Groups[3].Value == "do()")
    {
        doStuff = true;
        Console.WriteLine("Starting to do stuff");
        continue;
    }
    if (match.Groups[4].Value == "don't()")
    {
        doStuff = false;
        Console.WriteLine("Stopping to do stuff");
        continue;
    }
    if (!doStuff)
    {
        continue;
    }
    var a = int.Parse(match.Groups[1].Value);
    var b = int.Parse(match.Groups[2].Value);
    var result = a * b;
    sum += result;
    // wait for the user to press a key before continuing
    // Console.WriteLine($"Multiplying {a} by {b} equals {result}. Press any key to continue.");
    // Console.ReadKey();
}

Console.WriteLine("Sum of all multiplications: ");
Console.WriteLine(sum);