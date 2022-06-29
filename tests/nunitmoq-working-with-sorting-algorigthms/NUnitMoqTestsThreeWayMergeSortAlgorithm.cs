using lib;
using Moq;
using NUnit.Framework;

namespace nunitmoq_working_with_sorting_algorigthms
{
    /// <summary>
    /// Defines, sets up and implements the NUnit test(s) for the Three Way Merge Sort Algorithm
    /// </summary>
    public class NUnitTestsThreeWayMergeSortAlgorithm
    {
        private Mock<IThreeWayMergeSort> threeWayMergeSort;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}

