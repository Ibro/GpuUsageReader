Console.WriteLine("Starting to read GPU usage. Press ESC key to stop.");

var delay = TimeSpan.FromSeconds(2);

bool keepLooping = true;
while (keepLooping)
{
	// // Read the GPU usage
	// var line = GpuReader.GetLine();
	//
	// // Print out the GPU usage
	// Console.WriteLine(line);
	
	try
	{
		var gpuCounters = GpuReader.GetGPUCounters();         
		var gpuUsage = await GpuReader.GetGPUUsage(gpuCounters);
		Console.WriteLine(gpuUsage);
	} catch {}

	
	// // Exit if ESC key is pressed
	// if (Console.ReadKey().Key == ConsoleKey.Escape)
	// {
	// 	keepLooping = false;
	// }

	Console.WriteLine("Waiting....");
	await Task.Delay(delay);
}

Console.WriteLine("Done reading.");