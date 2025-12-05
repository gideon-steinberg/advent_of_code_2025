void Main()
{
	var input = @"";

	var lines = input.Split(Environment.NewLine);
	var processRanges = true;	
	var ranges = new List<Range>();	
	var part1 = 0;
	
	foreach (var line in lines)
	{
		if (line == "")
		{
			processRanges = false;
		} 
		else if (processRanges)
		{
			var parts = line.Split("-");
			ranges.Add(new Range {first = double.Parse(parts[0]), second = double.Parse(parts[1])});			
		} 
		else 
		{
			var spoiled = true;
			var num = double.Parse(line);
			foreach (var range in ranges)
			{
				if (range.first < num && range.second > num)
				{
					spoiled = false;
				}
			}
			
			if (!spoiled)
			{
				part1++;
			}
		}
	}
	
	Console.WriteLine(part1);
	var sortedRanges = ranges.OrderBy( r => r.first);
	var usefulRanges = new List<Range>{sortedRanges.First()};
	foreach (var r in sortedRanges.Skip(1))
	{
		if (r.first <= usefulRanges.Last().second)
		{
			usefulRanges.Last().second = Math.Max(r.second, usefulRanges.Last().second);
		}
		else
		{
			usefulRanges.Add(r);
		}
	}
	
	double part2 = 0;
	foreach (var r in usefulRanges)
	{
		part2 += r.second;
		part2 -= r.first;
		part2++;
	}
	
	Console.WriteLine(part2);
	
}

public class Range
{
	public double first;
	public double second;
}