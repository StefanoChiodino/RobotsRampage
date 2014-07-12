using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    using RobotsRampage.Game.Utility;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var vector2 = new Vector2(10, 10);
            const int max = 3;
            var initialLength = vector2.Length();
            vector2.Max(max);
            var finalLength = vector2.Length();

            Assert.AreEqual(Math.Floor(Math.Abs(finalLength - max)), 0);
        }
    }
}
