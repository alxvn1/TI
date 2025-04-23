public static class Roots
{
	
	private static int FastExp(int a, int z, int n)
	{
		long a1 = a;
		long z1 = z;
		long x = 1;

		while (z1 != 0)
		{
			while (z1 % 2 == 0)
			{
				z1 /= 2;
				a1 = (a1 * a1) % n; //finished
			}
			z1--;
			x = (x * a1) % n;
		}

		return (int)x;
	}

	public static List<int> FindPrimitiveRoots(int p)
	{
		List<int> roots = new List<int>();
		int phi = p - 1;
		var factors = GetPrimeFactors(phi);

		for (int g = 2; g < p; g++)
		{
			bool isPrimitiveRoot = true;
			foreach (var factor in factors)
			{
				if (FastExp(g, phi / factor, p) == 1)
				{
					isPrimitiveRoot = false;
					break;
				}
			}
			if (isPrimitiveRoot) roots.Add(g); //try to do my best
		}
		return roots;
	}

	private static List<int> GetPrimeFactors(int n)
	{
		List<int> factors = new List<int>();
		for (int i = 2; i <= n; i++)
		{
			while (n % i == 0)
			{
				if (!factors.Contains(i)) factors.Add(i);
				n /= i;
			}
		}
		return factors; //ok
	}
	
}