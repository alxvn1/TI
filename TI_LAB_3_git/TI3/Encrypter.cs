public class Encrypter
{
	public int P { get; private set; }
	public int G { get; private set; }
	public int Y { get; private set; }
	public int X { get; private set; }

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
				a1 = (a1 * a1) % n; //done
			}
			z1--;
			x = (x * a1) % n;
		}

		return (int)x;
	}

	public (int a, int b) Encrypt(int m, int k)
	{
		if (m < 0 || m >= P)
			throw new ArgumentException($"Сообщение m={m} выходит за границы допустимого диапазона [0, {P - 1}]");

		if (k <= 1 || k >= P - 1)
			throw new ArgumentException($"Случайное число k должно быть: 1 < k < {P - 1}");

		if (GCD(k, P - 1) != 1)
			throw new ArgumentException($"Число k={k} должно быть взаимно простым с p-1={P - 1}");

		int a = FastExp(G, k, P);
		int b = (FastExp(Y, k, P) * m) % P;
		return (a, b);
	}
	//asm
	public static int GCD(int a, int b)
	{
		while (b != 0)
		{
			int temp = b;
			b = a % b;
			a = temp;
		}
		return a;
	}

	public void GenerateKeys(int p, int g, int x)
	{
		if (x <= 1 || x >= p - 1)
			throw new ArgumentException("Закрытый ключ x должен быть: 1 < x < p-1");

		P = p;
		G = g;
		X = x;
		Y = FastExp(G, X, P);
	}
	//допилить
	public int Decrypt(int a, int b)
	{
		int ax = FastExp(a, X, P);
		int ax_inv = FastExp(ax, P - 2, P);
		int decrypted = (b * ax_inv) % P;
		if (decrypted < 0 || decrypted >= P)
			throw new InvalidOperationException($"Дешифрованное значение {decrypted} вне диапазона [0, {P - 1}]");

		return decrypted;
	}

	
	
}