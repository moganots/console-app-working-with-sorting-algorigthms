using lib;
using Moq;
using NUnit.Framework;

namespace nunitmoq_working_with_sorting_algorigthms
{
    /// <summary>
    /// Defines, sets up and implements the NUnit test(s) for the Bitonic Sort Algorithm
    /// </summary>
    public class NUnitTestsBitonicSortAlgorithm
    {
        private Mock<IBitonicSort> bitonicSort;

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

