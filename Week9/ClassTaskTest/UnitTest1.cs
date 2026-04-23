using ClassTask;
namespace ClassTaskTest
{
    public class Tests
    {
        [TestCase(true, true)]
        [TestCase(false, false)]
        public void IsOrderedWorksCorrectly(bool isAscending, bool expectedOutcome)
        {
            IComparable[] nums = { 1, 4, 6, 2, 9, 34, 1, 34, 23 };
            OrderedItemsHandler handler = new OrderedItemsHandler(nums);

            handler.Sort(SortingMethod.Bubble);
            bool actualOutcome = handler.IsOrdered(isAscending);

            Assert.That(expectedOutcome, Is.EqualTo(actualOutcome));
        }
    }
}

