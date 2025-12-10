void Main()
{
	var input = @"";

	var sum = 0;

	var lines = input.Split(Environment.NewLine);

	foreach (var line in lines)
	{
		Console.WriteLine("new problem");
		seen = new HashSet<string>();
		var parts = line.Split(" ");
		requiredOutput = parts[0].Replace("[", "").Replace("]", "").ToCharArray();
		requiredJoltage = parts.Last().Replace("{", "").Replace("}", "").Split(",").Select(s => int.Parse(s)).ToList();
		buttons = new List<List<int>>();
		outputLength = requiredOutput.Count();
		
		foreach (var button in parts.Skip(1).Take(parts.Count() - 2))
		{
			var numbers = button.Replace("(", "").Replace(")", "").Split(",").Select(int.Parse).ToList();
			buttons.Add(numbers);
		}
		
		buttonLength = buttons.Count();
		
		currentMin = 100000;
	
		
		for (var i = 0; i < buttonLength; i++)
		{
			var endResult = new char[outputLength];
			var joltages = new int[outputLength];
			
			Recurse(endResult, joltages, i, -1);
		}
		
		sum += currentMin;
	}
	
	sum.Dump();
}

public char[] requiredOutput;
public List<int> requiredJoltage;
public List<List<int>> buttons;
public int outputLength;
public int buttonLength;

public HashSet<string> seen;
public int currentMin;

public void Recurse(char[] currentOutput, int[] currentJoltage, int buttonPushed, int presses)
{
	if (presses > currentMin)
	{
		return;
	}
	var isCorrect = true;
	for (var i = 0; i < outputLength; i++)
	{
		if (currentJoltage[i] != requiredJoltage[i])// || currentOutput[i] != requiredOutput[i])
		{
			isCorrect = false;
		}
	}

	if (isCorrect)
	{
		if (currentMin > presses)
		{
			currentMin = presses;
		}
		return;
	}
	
	for (var i = 0; i < outputLength; i++)
	{
		if (currentJoltage[i] > requiredJoltage[i])
		{
			return;
		}
	}
	//string.Join("", currentOutput) + ":" +
	
	var key =  string.Join("", currentJoltage) + ":" + buttonPushed;
	
	if (seen.Contains(key))
	{
		return;
	}
	
	seen.Add(key);

	var workingOutput = new char[outputLength];
	
	for (var a = 0; a < outputLength; a++)
	{
		workingOutput[a] = currentOutput[a];
	}
	
	var workingJoltage = new int[outputLength];
	
	for (var a = 0; a < outputLength; a++)
	{
		workingJoltage[a] = currentJoltage[a];
	}
	
	foreach (var button in buttons[buttonPushed])
	{
		workingJoltage[button]++;
		if (workingOutput[button] == '#')
		{
			workingOutput[button] = '.';
		}
		else if (workingOutput[button] == '.')
		{
			workingOutput[button] = '#';
		}
		else
		{
			workingOutput[button] = '.';
		}
	}

	for (var i = 0; i < buttonLength; i++)
	{
		Recurse(workingOutput, workingJoltage, i, presses + 1);
	}
}