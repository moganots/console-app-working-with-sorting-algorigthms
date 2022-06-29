using lib;
using Moq;
using NUnit.Framework;

namespace nunitmoq_working_with_sorting_algorigthms
{
    /// <summary>
    /// Defines, sets up and implements the NUnit test(s) for the Stooge Sort Algorithm
    /// </summary>
    public class NUnitTestsStoogeSortAlgorithm
    {
        private Mock<IStoogeSort> stoogeSort;

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

