using NumberSortingWebApp.Library.Algorithm.Sorting;

namespace NumberSortingTests.Algorithm.Sorting
{
    public class QuicksortTests
    {
        private ISort<int> sortingAlgorithm;

        [SetUp]
        public void Setup()
        {
            sortingAlgorithm = new Quicksort();
        }

        [Test]
        [TestCase(new int[] { 23, 24, 35, 40 }, new int[] { 23, 24, 35, 40 })]
        [TestCase(new int[] { 40, 35, 24, 23 }, new int[] { 23, 24, 35, 40 })]
        [TestCase(new int[] { 23, 35, 15, 643, 24, 9, 40 }, new int[] { 9, 15, 23, 24, 35, 40, 643 })]
        public void Test_Quicksort_Ascending(int[] unsortedArray, int[] expectedArray)
        {
            int[] sortedArray = sortingAlgorithm.Sort(unsortedArray, 1);
            Assert.That(sortedArray, Is.EqualTo(expectedArray));
        }

        [Test]
        [TestCase(new int[] { 40, 35, 24, 23 }, new int[] { 40, 35, 24, 23 })]
        [TestCase(new int[] { 23, 24, 35, 40 }, new int[] { 40, 35, 24, 23 })]
        [TestCase(new int[] { 23, 35, 15, 643, 24, 9, 40 }, new int[] { 643, 40, 35, 24, 23, 15, 9 })]
        public void Test_Quicksort_Descending(int[] unsortedArray, int[] expectedArray)
        {
            int[] sortedArray = sortingAlgorithm.Sort(unsortedArray, 0);
            Assert.That(sortedArray, Is.EqualTo(expectedArray));
        }
    }
}