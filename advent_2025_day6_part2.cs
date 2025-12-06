void Main()
{
	var input = @"";

	var lines = input.Split(Environment.NewLine);
	
	var height = lines.Count();
	var width = lines[0].Count();
	
	var grid = new char[height,width];
	var operands = new List<char>();
	
	for (var y = 0; y < height; y++)
	{
		for (var x = 0; x < width; x++)
		{	
			grid[y,x] = lines[y][x];
			if (lines[y][x] == '*' || lines[y][x] == '+')
			{
				operands.Add(lines[y][x]);
			}
		}
	}
	
	var numbers = new List<List<double>>();
	var currentNumbers = new List<string>();
	
	for (var x = 0; x < width; x++)
	{
		var isSpace = true;
		for (var y = 0; y < height -1; y++)
		{
			if (grid[y,x] != ' ')
			{
				isSpace = false;
			}
		}
		
		if (isSpace)
		{
			var nums = new List<double>();
			foreach (var number in currentNumbers)
			{
				nums.Add(double.Parse(number));
			}
			numbers.Add(nums);
			currentNumbers = new List<string>();
		}
		else
		{
			var number = "";
			for (var y = 0; y < height -1; y++)
			{
				if (grid[y,x] != ' ')
				{
					number = number + grid[y,x];
				}
			}
			currentNumbers.Add(number);
		}
	}
	
	var temp2 = new List<double>();
	foreach (var number in currentNumbers)
	{
		temp2.Add(double.Parse(number));
	}
	numbers.Add(temp2);
	currentNumbers = new List<string>();
	
	
	double part2 = 0;
	
	for (var i = 0; i < operands.Count();i++)
	{
		var op = operands[i];
		if (op == '*')
		{
			double sum = 1;
			for (var j = 0; j < numbers[i].Count();j++)
			{
				sum *= numbers[i][j];
			}
			part2 += sum;

		}
		if (op == '+')
		{
			double sum = 0;
			for (var j = 0; j < numbers[i].Count();j++)
			{
				sum += numbers[i][j];
			}
			part2 += sum;
		}
	}
	
	Console.WriteLine(part2);
}