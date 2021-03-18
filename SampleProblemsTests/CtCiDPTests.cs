using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProblemsTests
{
    [TestClass]
    public class CtCiDpTests
    {
       [TestMethod]
       public void TestClimbStairs()
        {
            var dpTest = new CtCiDp();
            var result = dpTest.TripleStep(15);
            Assert.AreEqual(result, 13);
        }
    }
}
