using Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Tests
{
    [TestClass()]
    public class ToolTests
    {
        [TestMethod()]
        public void IsPalindromTest()
        {
            Assert.IsTrue(Util.Tool.IsPalindrom("12321"));
            Assert.IsFalse(Util.Tool.IsPalindrom("12"));

        }

        [TestMethod()]
        public void IsMultiPalindriomTest()
        {
            Assert.IsTrue(Util.Tool.IsMultiPalindriom(9));
            Assert.IsFalse(Util.Tool.IsMultiPalindriom(8));


        }
    }
}