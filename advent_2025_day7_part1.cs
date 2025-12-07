void Main()
{
	var input = @"";

	var lines = input.Split(Environment.NewLine);
	
	var height = lines.Count();
	var width = lines[0].Count();
	
	var grid = new char[height,width];
	
	var startX = 0;
	var startY = 0;
	
	for (var x = 0; x < width; x++)
	{
		for (var y = 0; y < height; y++)	
		{
			if (lines[y][x] == 'S')
			{
				startX = x;
				startY = y;
				grid[y,x] = lines[y][x];
			}
			else
			{
			
				grid[y,x] = lines[y][x];
			}
		}
	}
	
	var seen = new HashSet<Point>();
	var queue = new List<Point>();
	queue.Add(new Point{X = startX, Y = startY});
	
	var result = 0;
	
	while (queue.Count() > 0)
	{
		var point = queue.First();
		queue.RemoveAt(0);
		
		if (seen.Contains(point))
		{
			continue;
		}
		
		seen.Add(point);
		try {
			if (grid[point.Y+1,point.X] == '^')
			{
				grid[point.Y+1,point.X + 1] = '|';
				queue.Add(new Point{Y = point.Y+1, X =point.X + 1});
				grid[point.Y+1,point.X - 1] = '|';
				queue.Add(new Point{Y = point.Y+1, X =point.X - 1});
				result++;
			}
			else 
			{
				grid[point.Y+1,point.X] = '|';
				queue.Add(new Point{Y = point.Y+1, X =point.X});
			}
		} catch(Exception){}
	}
	Console.WriteLine(result);
}
