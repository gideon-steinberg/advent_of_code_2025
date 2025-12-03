void Main()
{
	var input = @"";

	var lines = input.Split(Environment.NewLine);
	
	var y = lines.Count();
	var x = lines[0].Count();
	
	var grid = new int[y,x];
	
	for (var i = 0; i < x; i++)
	{
		for (var j = 0; j < y; j++)
		{
			grid[j,i] = int.Parse(lines[j][i].ToString());
		}
	}
	
	double max = 0;
	
	for (var j = 0; j < y; j++)
	{
		var previous = -1;
		var total = "";
		var numDigits = 12; // change to 2 for part 1
		for (var a = 0; a < numDigits; a++)
		{
			var current = previous+1;
			for (var i = current; i < x - (numDigits - a) + 1; i++)
			{
				if (grid[j,i] > grid[j,current])
				{
					current = i;
				}
			}
			total += grid[j,current];
			previous = current;
		}
		
		max += double.Parse(total);
	}
	
	max.Dump();
}