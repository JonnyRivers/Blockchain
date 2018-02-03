using System;

namespace Blockchain
{
    public class Blockchain<TContent> where TContent : IBlockContent
    {
        public Blockchain(int difficulty, TContent genesisBlockContent)
        {
            Difficultly = difficulty;
            Hash emptyHash = new Hash();
            GenesisBlock = new Block<TContent>(1, genesisBlockContent, emptyHash, difficulty);
        }

        public int Difficultly { get; private set; }
        public Block<TContent> GenesisBlock { get; private set; }
    }
}
