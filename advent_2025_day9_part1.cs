void Main()
{
	var input = @"";

	var lines = input.Split(Environment.NewLine);
	
	var points = new List<Point>();
	
	foreach (var line in lines)
	{
		var parts = line.Split(",");
		points.Add(new Point {X = int.Parse(parts[0]), Y = int.Parse(parts[1])});
	}
	
	decimal maxArea = -1;
	
	for (var i = 0; i < points.Count(); i++)
	{
		for (var j = i+1; j < points.Count(); j++)
		{
			var xDiff = Math.Abs(points[i].X - points[j].X * 1m) + 1;
			var yDiff = Math.Abs(points[i].Y - points[j].Y* 1m) + 1;

			var res = xDiff * yDiff;
			if (maxArea < res)
			{
				maxArea = res;
			}
		}
	}
	
	Console.WriteLine(maxArea);
	
}