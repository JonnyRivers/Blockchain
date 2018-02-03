using System;
using System.Collections.Generic;
using System.Text;

namespace Blockchain
{
    public class Hash
    {
        private byte[] m_hashBytes;

        internal Hash()
        {
            m_hashBytes = new byte[16];
            for(int byteIndex = 0; byteIndex < 16; ++byteIndex)
            {
                m_hashBytes[byteIndex] = 0;
            }
        }

        internal Hash(byte[] hashBytes)
        {
            m_hashBytes = new byte[hashBytes.Length];
            for (int byteIndex = 0; byteIndex < 16; ++byteIndex)
            {
                m_hashBytes[byteIndex] = hashBytes[byteIndex];
            }
        }

        public byte[] ToBytes()
        {
            return m_hashBytes;
        }
    }
}
