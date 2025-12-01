void Main()
{
	var input = @"";

var input3 = @"R1000";

var input4 = @"L190
R190
L190
R190
R50";

var input5 = @"R50
L1
L1
L98";

var input6 = @"R50
L1
L1
L98";

	var lines = input.Split(Environment.NewLine);
	var dial = 50;
	var part1 = 0;
	var part2 = 0;
	
	foreach (var line in lines)
	{
		var num = int.Parse(line.Substring(1));
		while (num >= 100)
		{
			part2++;
			num-=100;
		}
		
		if (line[0] == 'L')
		{
			if (dial != 0 && dial - num <= 0)
			{
				part2++;
			}
			dial -= num;
		}
		else 
		{
			if (dial != 0 && dial + num >= 100)
			{
				part2++;
			}
			dial += num;
		}
		
		dial += 100;
		dial %= 100;
		if (dial == 0)
		{
			part1++;
		}		
	}
	
	Console.WriteLine(part1);
	Console.WriteLine(part2);	
}