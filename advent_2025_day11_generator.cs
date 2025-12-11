void Main()
{
	var keys = new Dictionary<string, List<string>>();
	keys.Add("you", new List<string>());
	
	var currentKeys = new List<string>();
	var previousKeys = new List<string>{"you"};
	
	var random = new Random();
	
	for (var i = 0; i < 10; i++)
	{
		currentKeys = new List<string>();
		var r = random.Next(1,5);
		
		for (var j = 0; j < r; j++)
		{
			var r2 = random.Next(0,26);
			var r3 = random.Next(0,26);
			var r4 = random.Next(0,26);
			var k =  Convert.ToChar(r2 + 'a') + "" +  Convert.ToChar(r3 + 'a') + "" +  Convert.ToChar(r4 + 'a'); 
			currentKeys.Add(k);
		}
		foreach (var k1 in previousKeys)
		{
			keys[k1].AddRange(currentKeys);
		}
		previousKeys = currentKeys;
		
		foreach (var k1 in previousKeys)
		{
			keys.Add(k1, new List<string>());
		}
	}
	
	foreach (var k1 in previousKeys)
	{
		keys[k1].Add("out");
	}
	
	var keyList = keys.Keys.OrderBy( _ => random.Next());
	
	foreach (var k2 in keyList)
	{
		Console.WriteLine($"{k2}: {string.Join(" ", keys[k2])}");
	}
}