﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TDT.IdentityCore.Utils
{
    public class PasswordGenerator
    {
        private static readonly int SALT_SIZE = 32;
        private static readonly int ITERATIONS = 3000;
        public static string HashPassword(string password)
        {            
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, SALT_SIZE, ITERATIONS))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(SALT_SIZE * 2);
            }
            byte[] dst = new byte[SALT_SIZE + 1 + SALT_SIZE * 2];
            Buffer.BlockCopy(salt, 0, dst, 1, SALT_SIZE);
            Buffer.BlockCopy(buffer2, 0, dst, SALT_SIZE + 1, SALT_SIZE * 2);
            return Convert.ToBase64String(dst);
        }
        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != SALT_SIZE + 1 + SALT_SIZE * 2) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[SALT_SIZE];
            Buffer.BlockCopy(src, 1, dst, 0, SALT_SIZE);
            byte[] buffer3 = new byte[SALT_SIZE * 2];
            Buffer.BlockCopy(src, SALT_SIZE + 1, buffer3, 0, SALT_SIZE * 2);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, ITERATIONS))
            {
                buffer4 = bytes.GetBytes(SALT_SIZE * 2);
            }
            return ByteArraysEqual(buffer3, buffer4);
        }
        public static bool ByteArraysEqual(byte[] b1, byte[] b2)
        {
            if (b1 == b2) return true;
            if (b1 == null || b2 == null) return false;
            if (b1.Length != b2.Length) return false;
            for (int i = 0; i < b1.Length; i++)
            {
                if (b1[i] != b2[i]) return false;
            }
            return true;
        }
    }
}
