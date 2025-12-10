void Main()
{
	var input = @"";

	var sum = 0;

	var lines = input.Split(Environment.NewLine);

	foreach (var line in lines)
	{
		var parts = line.Split(" ");
		var required = parts[0].Replace("[", "").Replace("]", "");
		
		var buttons = new List<List<int>>();
		
		foreach (var button in parts.Skip(1).Take(parts.Count() - 2))
		{
			var numbers = button.Replace("(", "").Replace(")", "").Split(",").Select(int.Parse).ToList();
			buttons.Add(numbers);
		}
		
		var patterns = GenerateBinaryNumbers(buttons.Count());
		var minPresses = 100000;
		
		foreach (var pattern in patterns)
		{
			var endResult = new char[required.Count()];
			var presses = 0;
			for (var i = 0; i < required.Count(); i++)
			{
				endResult[i] = '.';
			}
			
			for (var i = 0; i < buttons.Count(); i++)
			{
				if (pattern[i] == '1')
				{
					presses++;
					foreach (var button in buttons[i])
					{
						if (endResult[button] == '#')
						{
							endResult[button] = '.';
						}
						else if (endResult[button] == '.')
						{
							endResult[button] = '#';
						}
						else
						{
							Console.WriteLine("How did this happen");
						}
					}
				}
			}
			if (string.Join("", endResult) == required && minPresses > presses)
			{
				minPresses = presses;
			}
		}
		
		sum += minPresses;
	}
	
	sum.Dump();
}

// yuck
public IEnumerable<string> GenerateBinaryNumbers(int power)
{
	for (var i = 0; i < Math.Pow(2, power); i++)
	{
		var current = i;
		var number = "";
		
		while (current > 0)
		{
			number += current % 2 + "";
			current = (int)Math.Floor((double)(current / 2));
		}
		
		while(power > number.Count())
		{
			number += "0";
		}
		
		yield return number;		
	}
}