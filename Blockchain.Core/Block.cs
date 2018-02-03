using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Blockchain
{
    public class Block<TContent> where TContent : IBlockContent
    {
        internal Block(int index, TContent content, Hash previousHash, int difficulty)
        {
            Index = index;
            At = DateTime.UtcNow;
            Content = content;
            PreviousHash = previousHash;

            GenerateHash(difficulty);
        }

        private void GenerateHash(int difficulty)
        {
            int nonce = 0;
            bool validHash = false;
            while(!validHash)
            {
                validHash = GenerateHash(difficulty, nonce);
                ++nonce;
            }
        }

        private bool GenerateHash(int difficultly, int nonce)
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(memoryStream);
            writer.Write(Index);
            long atBinary = At.ToBinary();
            writer.Write(atBinary);
            byte[] contentBytes = Content.ToBytes();
            writer.Write(contentBytes);
            byte[] previousHashBytes = PreviousHash.ToBytes();
            writer.Write(previousHashBytes);
            writer.Write(nonce);
            memoryStream.Position = 0;

            byte[] hashBytes = null;
            using (MD5 md5Hash = MD5.Create())
            {
                hashBytes = md5Hash.ComputeHash(memoryStream);
            }

            // TODO: check upper n(difficultly) bits
            bool hashVerified = VerifyHash(hashBytes, difficultly);

            if (hashVerified)
            {
                Hash = new Hash(hashBytes);
                Nonce = nonce;
            }

            return hashVerified;
        }

        private bool VerifyHash(byte[] bytes, int difficulty)
        {
            if (difficulty > 8)
                throw new ArgumentException("Method not yet smart enough for > 8 bits :-)");

            for (int bitIndex = 0; bitIndex < difficulty; ++bitIndex)
            {
                byte mask = (byte)(1 << (7 - bitIndex));
                bool bitIsZero = ((bytes[0] & mask) == 0);
                if (!bitIsZero)
                    return false;
            }

            return true;
        }

        public int Index { get; private set; }
        public DateTime At { get; private set; }
        public TContent Content { get; private set; }
        public Hash Hash { get; private set; }
        public Hash PreviousHash { get; private set; }
        public int Nonce { get; private set; }
    }
}
