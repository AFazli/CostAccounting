using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoniz.Framework.Core.Security
{
    public interface IHashProvider
    {
        string Hash(string plainText, string saltedValue);
    }
}
