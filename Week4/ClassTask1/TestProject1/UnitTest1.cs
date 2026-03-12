using ClassTask1;

namespace TestProject1
{
    public class Tests
    {
        [Test]
        public void TestCtor()
        {
            int[] numbers = {  };
            ArrayStatistics statistic = new ArrayStatistics(numbers);
            Assert.That(statistic.Sum, Is.EqualTo(0));
        }

        [Test]
        public void TestSum()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 5, 6 };
            ArrayStatistics statistic = new ArrayStatistics(numbers);
            Assert.That(statistic.Sum, Is.EqualTo(26));
        }

        [TestCase(new int[] {1, 2, 3, 4, 5 }, 0, false)]
        [TestCase(new int[] {1, 2, 3, 4, 5 }, 1, true)]
        [TestCase(new int[] {1, 2, 3, 4, 5 }, 5, true)]
        [TestCase(new int[] {1, 2, 3, 4, 5 }, 6, false)]
        public void TestCointains(int[] numbers, int input, bool output)
        {
            ArrayStatistics statistic = new ArrayStatistics(numbers);
            Assert.That(statistic.Contains(input), Is.EqualTo(output));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 4 }, true)]
        [TestCase(new int[] { 1, 2, 3, 5, 3 }, false)]
        public void TestSorted(int[] numbers, bool output)
        {
            ArrayStatistics statistic = new ArrayStatistics(numbers);
            Assert.That(statistic.Sorted, Is.EqualTo(output));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 4)]
        [TestCase(new int[] { 1, 2, 3, 5, 4 }, 1, 1)]
        public void TestFirstGreater(int[] numbers, int exp, int bigger)
        {
            ArrayStatistics statistic = new ArrayStatistics(numbers);
            Assert.That(statistic.FirstGreater(bigger), Is.EqualTo(exp));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 4 }, 3)]
        [TestCase(new int[] { 1, 2, 3, 5, 4 }, 2)]
        public void TestEvens(int[] numbers, int expected)
        {
            ArrayStatistics statistic = new ArrayStatistics(numbers);
            Assert.That(statistic.CountEvens, Is.EqualTo(expected));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4)]
        [TestCase(new int[] { 1, 2, 3, 5, 4 }, 3)]
        public void TestMaxIndex(int[] numbers, int expected)
        {
            ArrayStatistics statistic = new ArrayStatistics(numbers);
            Assert.That(statistic.MaxIndex, Is.EqualTo(expected));
        }
    }
}