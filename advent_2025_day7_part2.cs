void Main()
{
	var input = @"";

	var lines = input.Split(Environment.NewLine);
	
	Height = lines.Count();
	Width = lines[0].Count();
	
	Grid = new char[Height,Width];
	
	var startX = 0;
	var startY = 0;
	
	for (var x = 0; x < Width; x++)
	{
		for (var y = 0; y < Height; y++)	
		{
			if (lines[y][x] == 'S')
			{
				startX = x;
				startY = y;
				Grid[y,x] = lines[y][x];
			}
			else
			{
			
				Grid[y,x] = lines[y][x];
			}
		}
	}
	
	var result = Recurse(new Point{X = startX, Y = startY});
	Console.WriteLine(result);
}

public Dictionary<Point, double> DPTable = new Dictionary<Point, double>();
public char[,] Grid;
public int Height;
public int Width;

public double Recurse(Point point)
{
	if (DPTable.ContainsKey(point))
	{
		return DPTable[point];
	}
	
	if (point.Y == Height - 1)
	{
		return 1;
	}
	
	if (Grid[point.Y+1,point.X] == '^')
	{
		var left = Recurse(new Point{Y = point.Y+1, X =point.X + 1});
		var right = Recurse(new Point{Y = point.Y+1, X =point.X - 1});
		DPTable[point] = left + right;
		return left + right;
	}
	else 
	{
		var result = Recurse(new Point{Y = point.Y+1, X =point.X});
		DPTable[point] = result;
		return result;
	}
}