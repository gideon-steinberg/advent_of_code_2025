void Main()
{
	var input = @"";

	var lines = input.Split(Environment.NewLine);
	
	var height = input.Count();
	
	var numbers = new List<List<double>>();
	var operands = new List<string>();
	
	foreach (var line in lines)
	{
		var parts = line.Split(" ").Select(p => p.Trim()).Where(p => p != "");
		
		if (parts.First()[0] == '*' || parts.First()[0] == '-')
		{
			operands = parts.ToList();
		}
		else
		{
			numbers.Add(parts.Select(double.Parse).ToList());
		}
	}
	
	double part1 = 0;
	
	for (var i = 0; i < operands.Count();i++)
	{
		var op = operands[i];
		if (op == "*")
		{
			double sum = 1;
			for (var j = 0; j < numbers.Count();j++)
			{
				sum *= numbers[j][i];
			}
			part1 += sum;

		}
		if (op == "+")
		{
			double sum = 0;
			for (var j = 0; j < numbers.Count();j++)
			{
				sum += numbers[j][i];
			}
			part1 += sum;
		}
	}
	
	Console.WriteLine(part1);
}