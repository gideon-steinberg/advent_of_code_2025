void Main()
{
	var input = @"";

	var lines = input.Split(Environment.NewLine);
	
	var y = lines.Count();
	var x = lines[0].Count();
	
	var grid = new bool[y,x];
	
	for (var i = 0; i < x; i++)
	{
		for (var j = 0; j < y; j++)
		{
			grid[j,i] = lines[j][i] == '@';
		}
	}
	
	var part1 = 0;
	
	for (var i = 0; i < x; i++)
	{
		for (var j = 0; j < y; j++)
		{
			if (!grid[j,i]) continue;
			
			var numberNext = 0;
			
			var directions = new List<int>{-1,0,1};
			foreach (var a in directions)
			{
				foreach (var b in directions)
				{
					try {
						if (grid[j+a,i+b])
						{
							numberNext++;
						}
					} catch (Exception){}
				}
			}
			
			if (numberNext <= 4)
			{
				part1++;
			}
		}
	}
	
	var hasChanged = true;
	var part2 = 0;
	while (hasChanged)
	{
		hasChanged = false;
		for (var i = 0; i < x; i++)
		{
			for (var j = 0; j < y; j++)
			{
				if (!grid[j,i]) continue;
				
				var numberNext = 0;
				
				var directions = new List<int>{-1,0,1};
				foreach (var a in directions)
				{
					foreach (var b in directions)
					{
						try {
							if (grid[j+a,i+b])
							{
								numberNext++;
							}
						} catch (Exception){}
					}
				}
				
				if (numberNext <= 4)
				{
					grid[j,i] = false;
					hasChanged = true;
					part2++;
				}
			}
		}
		
	}
	
	Console.WriteLine(part1);
	Console.WriteLine(part2);
}