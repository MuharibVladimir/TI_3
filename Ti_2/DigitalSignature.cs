using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ti_3
{
    class DigitalSignature
    {
        public static BigInteger GetHash(string message, BigInteger p, BigInteger q, BigInteger h)
        {
            var n = p * q;

            foreach (var m in message)
            {
                h = RSA.FastExp(h + m, 2, n);
            }

            return h;

        }
    }
}
