Console.WriteLine("Starting to read GPU usage. Press ESC key to stop.");

var delay = TimeSpan.FromSeconds(2);

bool keepLooping = true;
while (keepLooping)
{
	// Read the GPU usage
	var line = GpuReader.GetLine();
	
	// Print out the GPU usage
	Console.WriteLine(line);

	
	// Exit if ESC key is pressed
	if (Console.ReadKey().Key == ConsoleKey.Escape)
	{
		keepLooping = false;
	}
	
	await Task.Delay(delay);
}

Console.WriteLine("Done reading.");