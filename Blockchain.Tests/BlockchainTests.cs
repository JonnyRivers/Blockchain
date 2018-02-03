using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockchain.Tests
{
    [TestClass]
    public class BlockchainTests
    {
        [TestMethod]
        public void TestTextContentBlockchainCreate()
        {
            var genesisBlockContent = new TextContent("Jonny is grate");
            var blockchain = new Blockchain<TextContent>(3, genesisBlockContent);
        }
    }
}
