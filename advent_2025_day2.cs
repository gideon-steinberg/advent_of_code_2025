void Main()
{
	var input = @"";
	
	var ranges = input.Split(",");
	double part1 = 0;
	double part2 = 0;
	
	var numsChecked = 0;
	foreach (var range in ranges)
	{
		var parts = range.Split("-");
		var first = double.Parse(parts[0]);
		var second = double.Parse(parts[1]);
		
		for (var i = first; i <= second; i++)
		{
			var str = i.ToString();
			if (str.Length % 2 == 0)
			{
				var firstStr = i.ToString().Substring(0, str.Length /2);
				var secondStr = i.ToString().Substring(str.Length /2, str.Length /2);
				if (firstStr == secondStr)
				{
					part1+=i;
				}
			}
			
			// Progress update to pretend that it isn't slow
			numsChecked++;
			if (numsChecked % 10000 == 0)
			{
				Console.WriteLine(numsChecked);
			}
			
			var isValidI = IsValidI(i);
			
			if (!isValidI)
			{
				part2+=i;
			}
		}
	}
	
	Console.WriteLine(part1);
	Console.WriteLine(part2);
	
}

public bool IsValidI(double i)
{
	var str = i.ToString();
	for (var j = 1; j <= str.Length + 2; j++)
	{
		
		if (str.Length % j == 0)
		{
			var firstStr = i.ToString().Substring(0, str.Length /j);
			var strs = new HashSet<string>{};
			var strsList = new List<string>{};
			for (var k = 0; k <= str.Length; k++)
			{
				try
				{
					var secondStr = str.Substring(str.Length /j * k, str.Length /j);
					strs.Add(secondStr);
					strsList.Add(secondStr);
				}
				catch (Exception)
				{
					// Can't be bothered fixing it
				}
			}
			if (strsList.Count > 1 && strs.Count == 1)
			{
				return false;
			}
		}
	}
	return true;
}