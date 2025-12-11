void Main()
{
	var input = @"";

	var lines = input.Split(Environment.NewLine);

	foreach (var line in lines)
	{
		var parts = line.Split(" ");
		var label = parts[0].Replace(":", "");
		devices[label] = parts.Skip(1).ToList();
	}
	
	Part1("you");
	Console.WriteLine(part1);
	
	var part2 = Part2("svr", "svr");
	Console.WriteLine(part2);
}

public double part1 = 0;

public Dictionary<string, List<string>> devices = new Dictionary<string, List<string>>();

public void Part1(string label)
{
	if (label == "out")
	{
		part1++;
		return;
	}
	
	
	if (!devices.ContainsKey(label))
	{
		Console.WriteLine("huh?");
		return;
	}
	
	foreach (var newLabel in devices[label])
	{
		Part1(newLabel);
	}
}

public Dictionary<string, double> DPTable = new Dictionary<string, double>();

public double Part2(string label, string pathToGetHere)
{
	var key = label + "," + pathToGetHere;
	if (DPTable.ContainsKey(key))
	{
		return DPTable[key];
	}
	
	if (label == "out")
	{
		if (pathToGetHere.Contains("dac") && pathToGetHere.Contains("fft"))
		{
			return 1;
		}
		return 0;
	}
	
	
	if (!devices.ContainsKey(label))
	{
		Console.WriteLine("huh?");
		return 0;
	}
	
	double sum = 0;
	
	foreach (var newLabel in devices[label])
	{
		var newPath = pathToGetHere;
		if (newLabel == "dac" || newLabel == "fft")
		{
			newPath =  pathToGetHere + ":" + newLabel;
		}
		sum += Part2(newLabel, newPath);
	}
	
	DPTable[key] = sum;
	
	return sum;
}