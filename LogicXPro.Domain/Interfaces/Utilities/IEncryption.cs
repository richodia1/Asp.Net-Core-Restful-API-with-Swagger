using System;
using System.Collections.Generic;
using System.Text;

namespace LogicXPro.Domain.Interfaces.Utilities
{
   public interface IEncryption
    {
        string Encrypt(string plainText);
    }
}
