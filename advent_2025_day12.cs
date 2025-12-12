void Main()
{
	var input = @"";
	
	var lines = input.Split(Environment.NewLine);
	
	var isPresents = true;
	var y = 0;
	
	var sum = 0;
	var sum2 = 0;
	
	List<Point> currentPresent = null;
	
	foreach (var line in lines)
	{
		if (line.Contains("x"))
		{
			if (currentPresent != null)
			{
				presents.Add(currentPresent);
				currentPresent = null;
			}
			isPresents = false;
		}
		
		if (isPresents)
		{
			if (line.Contains(":"))
			{
				y = 0;
				if (currentPresent != null)
				{
					presents.Add(currentPresent);
				}
				currentPresent = new List<Point>();
			} 
			else if (line.Contains(".") || line.Contains("#"))
			{
				for (var i = 0; i < line.Count(); i++)
				{
					if (line[i] == '#')
					{
						currentPresent.Add(new Point{X = i, Y = y});
					}
				}
				y++;
			}
		}
		else
		{
			seen = new HashSet<string>();
			var parts = line.Split(": ");
			var parts2 = parts[0].Split("x");
			width = int.Parse(parts2[0]);
			height = int.Parse(parts2[1]);
			
			numbers = parts[1].Split(" ").Select(int.Parse).ToList();
			
			var area = width * height;
			var count = 0;
			var numPresents = 0;
			for (var i = 0; i < numbers.Count; i++)
			{
				count += numbers[i] * presents[i].Count();
				numPresents += numbers[i];
			}
			
			if (count <= area)
			{
				sum++;
			}
			
			var numPossible = Math.Floor(width / 3.0) * Math.Floor(height / 3.0);
			if (numPresents <= numPossible)
			{
				sum2++;
			}
			
			/*
			
			var grid = new bool[height,width];
			numbersCount = numbers.Count();
			var numbersUsed = new int[numbersCount];
			for (var i = 0; i < numbers.Count(); i++)
			{
				numbersUsed[i] = 0;
			}
			
			for (var i = 0; i < height; i++)
			{
				for (var j = 0; j < width; j++)
				{
					grid[i,j] = false;
				}
			}
			
			if (Recurse(grid, numbersUsed))
			{
				sum++;
			}*/		
		}
	}
	
	Console.WriteLine(sum);
	Console.WriteLine(sum2);
}

public List<List<Point>> presents = new List<List<Point>>();
public int height;
public int width;
public List<int> numbers;
public int numbersCount;
public int iterations = 0;

public HashSet<string> seen = new HashSet<string>();

public bool Recurse(bool[,] grid, int[] numbersUsed)
{
	var key = "";
	for (var y = 0; y < height; y++)
	{
		for (var x = 0; x < width; x++)
		{			
			if (grid[y,x])
			{
				key += $"{y},{x}:";
			}
		}
	}
	
	for (var i = 0; i < numbersCount; i++)
	{
		key += numbersUsed[i];
		key += ";";
	}
	
	if (seen.Contains(key))
	{
		return false;
	}
	seen.Add(key);
	
	iterations++;
	if (iterations % 1000 == 0)
	{
		iterations.Dump();
	}
	
	var isComplete = true;
	for (var i = 0; i < numbersCount; i++)
	{		
		if (numbersUsed[i] != numbers[i])
		{
			isComplete = false;
		}
		if (numbersUsed[i] > numbers[i])
		{
			return false;
		}
	}
	
	if (isComplete)
	{
		//grid.Dump();
		return true;
	}
	
	for (var i = 0; i < numbersCount; i++)
	{
		if (numbersUsed[i] >= numbers[i])
		{
			continue;
		}
		//$"{i}, {numbersUsed[i]} vs {numbers[i]}".Dump();
		for (var y = 0; y < height; y++)
		{
			for (var x = 0; x < width; x++)
			{				
				try {
					var clone = CloneGrid(grid);
					foreach (var point in presents[i])
					{							
						if (clone[y + point.Y,x + point.X])
						{
							// I hate myself but it's fine
							// This is if it exists
							throw new ArgumentException();
						}
						clone[y + point.Y,x + point.X] = true;
					}
					var clonedNumbersUsed = new int[numbersCount];
					for (var j = 0; j < numbersCount; j++)
					{
						clonedNumbersUsed[j] = numbersUsed[j];
					}
					clonedNumbersUsed[i]++;
					//$"{i}, {x}, {y}".Dump();
					if (Recurse(clone, clonedNumbersUsed))
					{
						return true;
					}
				} catch (Exception){}
				
				try {
					var clone = CloneGrid(grid);
					foreach (var point in presents[i])
					{							
						if (clone[y + point.Y,x - point.X])
						{
							// I hate myself but it's fine
							// This is if it exists
							throw new ArgumentException();
						}
						clone[y + point.Y,x - point.X] = true;
					}
					var clonedNumbersUsed = new int[numbersCount];
					for (var j = 0; j < numbersCount; j++)
					{
						clonedNumbersUsed[j] = numbersUsed[j];
					}
					clonedNumbersUsed[i]++;
					//$"{i}, {x}, {y}".Dump();
					if (Recurse(clone, clonedNumbersUsed))
					{
						return true;
					}
				} catch (Exception){}
				
				try {
					var clone = CloneGrid(grid);
					foreach (var point in presents[i])
					{							
						if (clone[y - point.Y,x + point.X])
						{
							// I hate myself but it's fine
							// This is if it exists
							throw new ArgumentException();
						}
						clone[y - point.Y,x + point.X] = true;
					}
					var clonedNumbersUsed = new int[numbersCount];
					for (var j = 0; j < numbersCount; j++)
					{
						clonedNumbersUsed[j] = numbersUsed[j];
					}
					clonedNumbersUsed[i]++;
					//$"{i}, {x}, {y}".Dump();
					if (Recurse(clone, clonedNumbersUsed))
					{
						return true;
					}
				} catch (Exception){}
				
				try {
					var clone = CloneGrid(grid);
					foreach (var point in presents[i])
					{							
						if (clone[y - point.Y,x - point.X])
						{
							// I hate myself but it's fine
							// This is if it exists
							throw new ArgumentException();
						}
						clone[y - point.Y,x - point.X] = true;
					}
					var clonedNumbersUsed = new int[numbersCount];
					for (var j = 0; j < numbersCount; j++)
					{
						clonedNumbersUsed[j] = numbersUsed[j];
					}
					clonedNumbersUsed[i]++;
					//$"{i}, {x}, {y}".Dump();
					if (Recurse(clone, clonedNumbersUsed))
					{
						return true;
					}
				} catch (Exception){}
			}
		}
	}
	
	return false;
}

public bool CheckValid(int[] numbersUsed)
{
	var isComplete = true;
	for (var i = 0; i < numbersCount; i++)
	{		
		if (numbersUsed[i] != numbers[i])
		{
			isComplete = false;
		}
	}
	
	return isComplete;	
}

public bool[,] CloneGrid(bool[,] grid)
{
	var clone = new bool[height,width];
	
	/*for (var y = 0; y < height; y++)
	{
		for (var x = 0; x < width; x++)
		{
			clone[y,x] = false;//grid[y,x];
		}
	}*/
	
	// Apparently the speed here doesn't matter :(
	System.Buffer.BlockCopy(grid, 0, clone, 0, height*width);
	return clone;
}