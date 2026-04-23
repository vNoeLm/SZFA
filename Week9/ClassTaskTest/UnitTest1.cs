using ClassTask;
namespace ClassTaskTest
{
    public class Tests
    {
        [TestCase(true, true)]
        [TestCase(false, false)]
        public void IsOrderedWorksCorrectly(bool isAscending, bool expectedOutcome)
        {
            IComparable[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            OrderedItemsHandler handler = new OrderedItemsHandler(nums);

            bool actualOutcome = handler.IsOrdered(isAscending);
            Assert.That(expectedOutcome, Is.EqualTo(actualOutcome));
        }

        [TestCase(SortingMethod.Bubble)]
        [TestCase(SortingMethod.Selection)]
        [TestCase(SortingMethod.Insertion)]
        public void SortingMethodsSortsAscending(SortingMethod sortingMethod)
        {
            IComparable[] nums = { 1, 5, 23, 2, 56, 3, 1, 34, 89, 35, 22, 11 };
            OrderedItemsHandler handler = new OrderedItemsHandler(nums);

            handler.Sort(sortingMethod);
            Assert.That(true, Is.EqualTo(handler.IsOrdered()));
        }

        [Test]
        public void ReverseWorksOnOrderedArray()
        {
            IComparable[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            OrderedItemsHandler handler = new OrderedItemsHandler(nums);

            handler.Reverse();
            Assert.That(true, Is.EqualTo(handler.IsOrdered(false)));
        }

        [TestCase(4, true)]
        [TestCase(8, true)]
        public void IterativeBinarySearchReturnCorrectResults(IComparable target, bool isAscending)
        {
            IComparable[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            OrderedItemsHandler handler = new OrderedItemsHandler(nums);

            IComparable result = handler.IterativeBinarySearch(target, isAscending);

            Assert.That(target, Is.EqualTo(result));
        }

        [Test]
        public void IterativeBinarySearchThrowsNotOrderedException()
        {
            IComparable[] nums = { 1, 5, 23, 2, 56, 3, 1, 34, 89, 35, 22, 11 };
            OrderedItemsHandler handler = new OrderedItemsHandler(nums);

            Assert.Throws<NotOrderedItemsException>(() => handler.IterativeBinarySearch(5));
        }

        [Test]
        public void IterativeBinarySearchThrowsItemNotFoundException()
        {
            IComparable[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            OrderedItemsHandler handler = new OrderedItemsHandler(nums);

            Assert.Throws<ItemNotFoundException>(() => handler.IterativeBinarySearch(11));
        }

        [Test]
        public void RecursiveBinarySearchReturnsCorrectResult()
        {
            IComparable[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            OrderedItemsHandler handler = new OrderedItemsHandler(nums);

            IComparable result = handler.RecursiveBinarySearch(3, true, 0, nums.Length - 1);
            Assert.That(3, Is.EqualTo(result));
        }

        [Test]
        public void RecursiveBinarySearchThrowsItemNotFoundException()
        {
            IComparable[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            OrderedItemsHandler handler = new OrderedItemsHandler(nums);

            Assert.Throws<ItemNotFoundException>(() => handler.RecursiveBinarySearch(11, true, 0, nums.Length - 1));
        }

        [TestCase(4, 3)]
        [TestCase(20, 9)]
        public void FindIndexOfLargerOrEqualNumberReturnsCorrectIndex(IComparable target, int expected)
        {
            IComparable[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9 , 34, 56, 78};
            OrderedItemsHandler handler = new OrderedItemsHandler(nums);

            Assert.That(expected, Is.EqualTo(handler.FindIndexOfLargerOrEqualNumber(target)));
        }

        [Test]
        public void FindIndexOfLargerNumberReturnsIndexOfFirstLargerNumber()
        {
            IComparable[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 34, 56, 78 };
            OrderedItemsHandler handler = new OrderedItemsHandler(nums);

            Assert.That(2, Is.EqualTo(handler.FindIndexOfLargerNumber(2)));
        }

        [TestCase(2, 3)]
        [TestCase(55, 0)]
        public void CountEqualToTargetReturnsCorrectCount(int target,int expected)
        {
            IComparable[] nums = { 1, 2, 2, 2, 3, 4, 5, 6, 7, 8, 9, 34, 56, 78 };
            OrderedItemsHandler handler = new OrderedItemsHandler(nums);

            int actual = handler.CountEqualToTarget(target);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [TestCase(2, 5, 6)]
        [TestCase(100, 200, 0)]
        public void CountItemsInRangeReturnsCorrentCount(int start, int end, int expected)
        {
            IComparable[] nums = { 1, 2, 2, 2, 3, 4, 5, 6, 7, 8, 9, 34, 56, 78 };
            OrderedItemsHandler handler = new OrderedItemsHandler(nums);

            int actual = handler.CountItemsInRange(start, end);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [TestCase(new int[] { 2, 2, 2, 3 }, 2, 3)]
        public void GetItemsInRangeReturnCorrectArray(int[] expected, int start, int end)
        {
            IComparable[] nums = { 1, 2, 2, 2, 3, 4, 5, 6, 7, 8, 9, 34, 56, 78 };
            OrderedItemsHandler handler = new OrderedItemsHandler(nums);

            IComparable[] result = handler.GetItemsInRange(start, end);
            Assert.That(expected, Is.EqualTo(result));
        }
    }
}

