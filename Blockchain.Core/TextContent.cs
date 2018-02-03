using System;
using System.Collections.Generic;
using System.Text;

namespace Blockchain
{
    public class TextContent : IBlockContent
    {
        public TextContent(string text)
        {
            Text = text;
        }

        public string Text { get; private set; }

        public byte[] ToBytes()
        {
            return ASCIIEncoding.Default.GetBytes(Text);
        }
    }
}
