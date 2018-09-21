using LogicXPro.Domain.Interfaces.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace LogicXPro.Domain
{
   public class MD5Encrpytion: IEncryption
    {
        public string Encrypt(string plainText)
        {
            using (MD5 md5 = MD5.Create())
                return md5.ComputeHash(Encoding.ASCII.GetBytes(plainText))
                          .Select(x => x.ToString("X2"))
                          .Aggregate((ag, s) => ag + s);
        }
    }
}
