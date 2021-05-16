using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ti_3
{
    public class RSA
    {
        public long p, q, r, e, d;

        public RSA()
        {
            Initialize();
        }

        private void Initialize()
        {
            
                p = Keys.Generate();
                q = Keys.Generate();
            

            r = p * q;
            var fi = (p - 1) * (q - 1);

            e = GetPublicPartKey(fi);
            d = GetPrivatePartKey(e, fi);
        }

        private long GetPublicPartKey(long fi)
        {
            long e = fi - 1;

            while (true)
            {
                if (Keys.IsPrime(e) && e < fi &&
                    BigInteger.GreatestCommonDivisor(new BigInteger(e), new BigInteger(fi)) == BigInteger.One)
                    break;

                --e;
            }

            return e;
        }

        private long GetPrivatePartKey(long e, long fi)
        {
            return EuclidAdvanced(e, fi);
        }


        public static BigInteger FastExp(BigInteger a, BigInteger z, BigInteger n)
        {
            BigInteger a1 = a, z1 = z, x = 1;
            while (z1 != 0)
            {
                while (z1 % 2 == 0)
                {
                    z1 = z1 / 2;
                    a1 = (a1 * a1) % n;
                }

                z1 = z1 - 1;
                x = (x * a1) % n;
            }

            return x;
        }

        private long EuclidAdvanced(long a, long n)
        {
            long d0 = n;
            long d1 = a;
            long y0 = 0;
            long y1 = 1;

            while (d1 > 1)
            {
                long q = d0 / d1;
                long d2 = d0 % d1;
                long y2 = y0 - q * y1;
                d0 = d1;
                d1 = d2;
                y0 = y1;
                y1 = y2;
            }

            return y1 < 0 ? y1 + n : y1;
        }
    }
}
