using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ClassTask
{
    public enum SortingMethod
    {
        Selection,
        Bubble,
        Insertion
    }
    public class OrderedItemsHandler
    {
        public readonly IComparable[] items;

        public OrderedItemsHandler(IComparable[] inputItems)
        {
            this.items = inputItems;
        }

        public bool IsOrdered(bool isAscending = true)
        {
            for (int i = 0; i < items.Length - 1; i++)
            {
                int comp = items[i].CompareTo(items[i + 1]);
                if (isAscending)
                {
                    if (comp > 0) return false;
                }
                else
                {
                    if (comp < 0) return false;
                }
            }
            return true;
        }

        public void Sort(SortingMethod sortingMethod, bool isAscending = true)
        {
            switch (sortingMethod)
            {
                case SortingMethod.Selection:
                    SelectionSort();
                    break;
                case SortingMethod.Bubble:
                    BubbleSort();
                    break;
                case SortingMethod.Insertion:
                    InsertionSort();
                    break;
            }
            if (!isAscending) Reverse();
        }

        // Sorting Methods
        #region
        private void SelectionSort()
        {
            for (int i = 0; i < items.Length - 1; i++)
            {
                int minIdx = i;
                for (int j = i + 1; j < items.Length; j++)
                {
                    if (items[j].CompareTo(items[minIdx]) < 0)
                    {
                        minIdx = j;
                    }
                }
                IComparable temp = items[i];
                items[i] = items[minIdx];
                items[minIdx] = temp;
            }
        }
        private void BubbleSort()
        {
            bool swapped;
            for (int i = 0; i < items.Length; i++)
            {
                swapped = false;
                for (int j = 0; j < items.Length - 1 - i; j++)
                {
                    if (items[j].CompareTo(items[j + 1]) > 0)
                    {
                        IComparable temp = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped) return;
            }
        }
        private void InsertionSort()
        {
            for (int i = 1; i < items.Length; i++)
            {
                IComparable item = items[i];
                int j = i - 1;
                while (j >= 0 && items[j].CompareTo(item) > 0)
                {
                    items[j + 1] = items[j];
                    j--;
                }
                items[j + 1] = item;
            }
        }
        public void Reverse()
        {
            int start = 0;
            int end = items.Length - 1;
            while (start < end)
            {
                IComparable temp = items[start];
                items[start] = items[end];
                items[end] = temp;
                start++;
                end--;
            }
        }
        #endregion

        // Search Methods
        #region
        public IComparable IterativeBinarySearch(IComparable target, bool isAscending = true)
        {
            if (!IsOrdered(isAscending))
            {
                throw new NotOrderedItemsException(this.items);
            }

            int left = 0;
            int right = items.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int comparison = target.CompareTo(items[mid]);

                if (comparison == 0) return items[mid];

                if (isAscending)
                {
                    if (comparison < 0) right = mid - 1;
                    else left = mid + 1;
                }
                else
                {
                    if (comparison < 0) left = mid + 1;
                    else right = mid - 1;
                }
            }
            throw new ItemNotFoundException();
        }

        public IComparable RecursiveBinarySearch(IComparable target, bool isAscending, int left, int right)
        {
            if (right >= left)
            {
                int mid = left + (right - left) / 2;
                int comparison = target.CompareTo(items[mid]);

                if (comparison == 0) return items[mid];

                if (isAscending)
                {
                    if (comparison < 0) return RecursiveBinarySearch(target, isAscending, left, mid - 1);
                    else return RecursiveBinarySearch(target, isAscending, mid + 1, right);
                }
                else
                {
                    if (comparison < 0) return RecursiveBinarySearch(target, isAscending, mid + 1, right);
                    else return RecursiveBinarySearch(target, isAscending, left, mid - 1);
                }
            }
            throw new ItemNotFoundException();
        }
        #endregion

        public int FindIndexOfLargerOrEqualNumber(IComparable target, bool isAscending = true)
        {
            if (!IsOrdered(isAscending)) throw new NotOrderedItemsException(this.items);

            int left = 0;
            int right = items.Length - 1;
            int index = 0;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int comparison = items[mid].CompareTo(target);

                if (comparison >= 0 )
                {
                    index = mid;
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return index;
        }

        public int FindIndexOfLargerNumber(IComparable target, bool isAscending = true)
        {
            if (!IsOrdered(isAscending)) throw new NotOrderedItemsException(this.items);

            int left = 0;
            int right = items.Length - 1;
            int index = 0;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int comparison = items[mid].CompareTo(target);

                if (comparison > 0)
                {
                    index = mid;
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return index;
        }

        public int CountEqualToTarget(IComparable target, bool isAscending = true)
        {
            if (!IsOrdered(isAscending)) throw new NotOrderedItemsException(this.items);

            int firstTarget = FindIndexOfLargerOrEqualNumber(target, isAscending);
            int GreaterThanTarget = FindIndexOfLargerNumber(target, isAscending);

            int count = GreaterThanTarget - firstTarget;

            return count;
        }

        public int CountItemsInRange(IComparable start, IComparable end, bool isAscending = true)
        {
            if (!IsOrdered(isAscending)) throw new NotOrderedItemsException(this.items);

            int first = FindIndexOfLargerOrEqualNumber(start, isAscending);
            int last = FindIndexOfLargerNumber(end, isAscending);
            int count = last - first;

            return count;
        }

        public IComparable[] GetItemsInRange(IComparable start, IComparable end, bool isAscending = true)
        {
            int first = FindIndexOfLargerOrEqualNumber(start, isAscending);
            int last = FindIndexOfLargerNumber(end, isAscending);
            int count = last - first;

            IComparable[] res = new IComparable[count];
            for (int i = 0; i < count; i++)
            {
                res[i] = items[first + i];
            }
            return res;
        }
    }
}
