using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems;

namespace SampleProblemsTests
{
    [TestClass]
    public class SampleProblemsTests
    {
        [TestMethod]
        public void TestQueueWithStacks()
        {
            var queue = new QueueWithStacks<int>();
            queue.Enqueue(5);
            queue.Enqueue(4);
            queue.Enqueue(3);
            Assert.AreEqual(queue.Peek(), 5);
            queue.Dequeue();
            Assert.AreEqual(queue.Peek(), 4);
        }

        [TestMethod]
        public void ThreeSumTest()
        {
            SampleProblems prob = new SampleProblems();
            int[] input = { -2,0,0,2,2 }; //-4,-1,-1,0,1,2
            var solutionSet = prob.ThreeSum(input);
            Assert.AreEqual(solutionSet.Count, 1);
            int[] diffInput = { -4,-1,-1,0,1,2};
            solutionSet = prob.ThreeSum(diffInput);
            Assert.AreEqual(solutionSet.Count, 2);
        }

        [TestMethod]
        public void HammingTest()
        {
            SampleProblems prob = new SampleProblems();
            
            Assert.AreEqual(prob.HammingDistance(1, 4), 2);
        }
    }
}
