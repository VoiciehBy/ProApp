using System;

/// <summary>
/// Set of utility methods inside static Utility class.
/// </summary>
public static class Utility
{
	public static double randomDouble()
    {
        Random random = new Random();
        return random.NextDouble();
    }
}
