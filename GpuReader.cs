using System.Diagnostics.CodeAnalysis;

namespace GpuUsageReader;

[SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
public class GpuReader
{
	public static List<PerformanceCounter> GetGPUCounters()
	{
		var category = new PerformanceCounterCategory("GPU Engine");
		var counterNames = category.GetInstanceNames();

		var gpuCounters = counterNames
			.Where(counterName => counterName.EndsWith("engtype_3D"))
			.SelectMany(counterName => category.GetCounters(counterName))
			.Where(counter => counter.CounterName.Equals("Utilization Percentage"))
			.ToList();
            
		return gpuCounters;
	}
    
	public static async Task<float> GetGPUUsage(List<PerformanceCounter> gpuCounters)
	{
		gpuCounters.ForEach(x => x.NextValue());

		await Task.Delay(1000);

		var result = gpuCounters.Sum(x => x.NextValue());

		return result;
	}

	public static string GetLine()
	{
		var data = GetData();
		var sb = new StringBuilder();

		foreach (var performanceCounter in data)
		{
			sb.AppendLine($"{performanceCounter.CategoryName} {performanceCounter.RawValue}");
		}

		sb.AppendLine("--------------------");

		return sb.ToString();
	}

	public static List<PerformanceCounter> GetData()
	{
		var list = new List<PerformanceCounter>();
		var category = new PerformanceCounterCategory("GPU Engine");
		var names = category.GetInstanceNames();
		foreach (var name in names)
		{
			list.AddRange(category.GetCounters(name));
		}

		return list;
	}
}