using System;
using System.Numerics;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ti_3
{
    public static class Keys
    {
       
            private static readonly Random Random = new Random();

            public static long Generate()
            {
                const int left = 1000, right = 2000;
                long number;

                while (true)
                {
                    number = Random.Next(left, right);
                    if (IsPrime(number))
                        break;
                }

                return number;
            }

            public static bool IsPrime(long number)
            {
                const int rounds = 10;

                if (!MRTest(number, rounds)) return false;

                for (long i = 2; i <= Math.Sqrt(number); i++)
                    if (number % i == 0)
                        return false;

                return true;
            }

            private static bool MRTest(BigInteger n, int m)
            {
                if (n == 2 || n == 3)
                    return true;

                if (n < 2 || n % 2 == 0)
                    return false;

                BigInteger k = n - 1;
                int s = 0;

                while (k % 2 == 0)
                {
                    k /= 2;
                    s += 1;
                }

                var rng = new RNGCryptoServiceProvider();
                for (int i = 0; i < m; i++)
                {
                    byte[] randomArray = new byte[n.ToByteArray().LongLength];

                    BigInteger t;

                    do
                    {
                        rng.GetBytes(randomArray);
                        t = new BigInteger(randomArray);
                    } while (t < 2 || t >= n - 2);

                    BigInteger x = BigInteger.ModPow(t, k, n);

                    if (x == 1 || x == n - 1)
                        continue;

                    for (int r = 1; r < s; r++)
                    {
                        x = BigInteger.ModPow(x, 2, n);

                        if (x == 1)
                            return false;

                        if (x == n - 1)
                            break;
                    }

                    if (x != n - 1)
                        return false;
                }

                return true;
            }
        }

    }
