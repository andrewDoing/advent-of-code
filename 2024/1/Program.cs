// See https://aka.ms/new-console-template for more information

string CALC_TYPE = "similarity";

// open text file
string path = @"./input.txt";

// read all lines of text file
string[] lines = File.ReadAllLines(path);
Console.WriteLine(lines[0]);

// create a left list and a right list of ints from the lines
List<int> left = new List<int>();
List<int> right = new List<int>();

// pattern
foreach (string line in lines) {
    string[] parts = line.Split(["   "], StringSplitOptions.TrimEntries);
    left.Add(int.Parse(parts[0]));
    Console.WriteLine(parts[1]);
    right.Add(int.Parse(parts[1]));
}

var result = Calculate(CALC_TYPE, left, right);

Console.WriteLine("Sum of calculation: ");
Console.WriteLine(result);

// facade function
int Calculate(string calcType, List<int> left, List<int> right) {
    if (calcType == "difference") {
        return CalculateDifference(left, right);
    } else if (calcType == "similarity") {
        return CalculateSimiliarity(left, right);
    } else {
        throw new Exception("Invalid type");
    }
}

// function for part 1
int CalculateDifference(List<int> left, List<int> right) {
    // sort the left and right lists
    left.Sort();
    right.Sort();

    // assert that the lists are the same length
    if (left.Count != right.Count) {
        throw new Exception("Lists are not the same length");
    }

    var distances_sum = 0;
    // iterate through both lists simultaneously
    for (int i = 0; i < left.Count; i++) {
        // calculate the distance between the two points
        int distance = Math.Abs(left[i] - right[i]);
        distances_sum += distance;
    }

    return distances_sum;
}

// part 2
int CalculateSimiliarity(List<int> left, List<int> right) {
    // sort the left and right lists
    left.Sort();
    right.Sort();

    // assert that the lists are the same length
    if (left.Count != right.Count) {
        throw new Exception("Lists are not the same length");
    }

    // var leftDict = new Dictionary<int, int>();
    var rightDict = new Dictionary<int, int>();

    // populate the dictionaries with the unique values and their counts
    for(int i = 0; i < left.Count; i++) {
        // if (leftDict.ContainsKey(left[i])) {
        //     leftDict[left[i]]++;
        // } else {
        //     leftDict[left[i]] = 1;
        // }
        if (rightDict.ContainsKey(right[i])) {
            rightDict[right[i]]++;
        } else {
            rightDict[right[i]] = 1;
        }
    }

    var leftSimiliarity = 0;

    foreach (var val in left) {
        if (rightDict.ContainsKey(val)) {
            leftSimiliarity += val * rightDict[val];
        }
    }

    // var rightSimiliarity = 0;

    // foreach (var val in right) {
    //     if (leftDict.ContainsKey(val)) {
    //         rightSimiliarity += val * leftDict[val];
    //     }
    // }

    return leftSimiliarity;
}