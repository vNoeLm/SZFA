using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTask1
{
    public class ArrayStatistics
    {
        int[] numbers;

        public ArrayStatistics(int[] numbers)
        {
            this.numbers = numbers ?? new int[0];
        }

        public int Sum()
        {
            int sum = 0;
            foreach (int i in numbers)
            {
                sum += i;
            }
            return sum;
        }

        public bool Contains(int number)
        {
            foreach (int i in numbers)
            {
                if (i == number) return true;
            }
            return false;
        }

        public bool Sorted()
        {
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < numbers[i - 1])
                {
                    return false;
                }
            }
            return true;
        }

        public int FirstGreater(int number)
        {
            int index = 0;
            while (numbers[index] <= number)
            {
                index++;
            }
            if (index < numbers.Length)
            {
                return index;
            }
            return -1;
        }

        public int CountEvens()
        {
            int evens = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    evens++;
                }
            }
            return evens;
        }

        public int MaxIndex()
        {
            int maxIndex = 0;
            int max = int.MinValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    maxIndex = i;
                    max = numbers[i];
                }
            }
            return maxIndex;
        }

        public void Sort()
        {
            for (int i = 0;i < numbers.Length - 1;i++)
            {
                int min = i;
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] < min)
                    {
                        min = numbers[j];
                    }
                }

            }
        }
    }
}
