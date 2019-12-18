using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string sifre, out byte[] sifrele, out byte[] sifrecoz)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                sifrecoz = hmac.Key;
                sifrele = hmac.ComputeHash(Encoding.UTF8.GetBytes(sifre));
            }
        }

        public static bool VerifyPasswordHash(string sifre, byte[] sifrele, byte[] sifrecoz)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(sifrecoz))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(sifre));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != sifrele[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
