void Main()
{
	var input = @"";

	var lines = input.Split(Environment.NewLine);
	
	var points = new List<Point>();
	
	foreach (var line in lines)
	{
		var parts = line.Split(",");
		points.Add(new Point{X = int.Parse(parts[0]), Y = int.Parse(parts[1]), Z = int.Parse(parts[2])});
	}
	var minsJoined = new List<HashSet<Point>>();
	var distances = new List<PointPair>();
	
	for (var i = 0; i < points.Count(); i++)
	{
		for (var j = i+1; j < points.Count(); j++)
		{
			var d = points[i].Distance(points[j]);
			distances.Add(new PointPair {p1 = points[i], p2 = points[j], Distance = d});
		}
	}
	
	var distancesSorted = distances.OrderBy(d => d.Distance).ToList();
	
	for (var i = 0; i < distancesSorted.Count(); i++)
	{
		if (i == 1000)
		{
			var counts = minsJoined.Select(m => m.Count()).OrderBy(m => -m).ToList();
			var result = counts[0] * counts[1] * counts[2];
			
			Console.WriteLine(result);
		}
		
		if (minsJoined.Any() && minsJoined.First().Count() == points.Count())
		{
			var lastPs = distancesSorted[i-1];
			Console.WriteLine(lastPs.p1.X * lastPs.p2.X);
			return;
		}
		var d = distancesSorted[i];
		
		var foundP1 = -1;
		var foundP2 = -1;
		
		for (var a = 0; a < minsJoined.Count(); a++)
		{
			foreach (var newPoint in minsJoined[a])
			{
				if (newPoint.Equals(d.p1))
				{
					foundP1 = a;
				}
				
				if (newPoint.Equals(d.p2))
				{
					foundP2 = a;
				}
			}
		}
		if (foundP1 == -1 && foundP2 != -1)
		{	
			minsJoined[foundP2].Add(d.p1);
		} 
		else if (foundP1 != -1 && foundP2 == -1)
		{
			minsJoined[foundP1].Add(d.p2);
		}
		else if (foundP1 != -1 && foundP2 != -1)
		{
			if (foundP1 != foundP2)
			{
				foreach (var p3 in minsJoined[foundP2])
				{
					minsJoined[foundP1].Add(p3);
				}
				minsJoined.RemoveAt(foundP2);
			}
		}
		else
		{
			minsJoined.Add(new HashSet<Point>{d.p1, d.p2});
		}
	}
}

public class Point
{
	public int X;
	public int Y;
	public int Z;
	
	public double Distance(Point other)
	{
		return Math.Pow(X-other.X, 2) + Math.Pow(Y-other.Y, 2) + Math.Pow(Z-other.Z, 2);
	}
	
	public override int GetHashCode()
	{
		return X + Y * 100000 + Z * 100000 * 100000;
	}
	
	public override bool Equals(object other)
	{
		var point = (Point)other;
		return point.X == X && point.Y == Y && point.Z == Z;
	}
}

public class PointPair
{
	public Point p1;
	public Point p2;
	public double Distance;
}