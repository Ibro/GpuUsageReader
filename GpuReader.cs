namespace GpuUsageReader;

public class GpuReader
{
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