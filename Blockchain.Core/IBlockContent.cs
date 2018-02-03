using System;
using System.Collections.Generic;
using System.Text;

namespace Blockchain
{
    public interface IBlockContent
    {
        byte[] ToBytes();
    }
}
