using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ZH2
{
    internal class RaceResults
    {
        public RunnerWithTime[] results;

        public RaceResults(int runnerCount, string[] input)
        {
            results = new RunnerWithTime[runnerCount];

            for (int i = 0; i < runnerCount; i++)
            {
                results[i] = RunnerWithTime.Parse(input[i]);
            }

            if (!IsSorted())
            {
                JavitottBeillesztésesSort();
            }
        }

        private bool IsSorted()
        {
            for (int i = 1; i < results.Length; i++)
            {
                if (results[i - 1].CompareTo(results[i]) > 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void JavitottBeillesztésesSort()
        {
            for (int i = 1; i < results.Length; i++)
            {
                RunnerWithTime key = results[i];
                int j = i - 1;

                while (j >= 0 && results[j].CompareTo(key) > 0)
                {
                    results[j + 1] = results[j];
                    j--;
                }

                results[j + 1] = key;
            }
        }

        private int LowerBound(Time time)
        {
            if (!IsSorted()) throw new Exception("Nem Sorted!");

            int left = 0;
            int right = results.Length - 1;
            int index = 0;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int comparison = results[mid].CompareTo(time);

                if (comparison >= 0)
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

        private int UpperBound(Time time)
        {
            if (!IsSorted()) throw new Exception("Nem Sorted!");
            int left = 0;
            int right = results.Length - 1;
            int index = results.Length;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int comparison = results[mid].CompareTo(time);
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

        public RunnerWithTime[] GetRunnersInRange(Time start, Time end)
        {
            int first = LowerBound(start);
            int last = UpperBound(end);
            int count = last - first;

            RunnerWithTime[] res = new RunnerWithTime[count];
            for (int i = 0; i < count; i++)
            {
                res[i] = results[first + i];
            }
            return res;
        }
        public bool Contains(Predicate<RunnerWithTime> predicate, out RunnerWithTime runnerPerformance)
        {
            foreach (var runner in results)
            {
                if (predicate(runner))
                {
                    runnerPerformance = runner;
                    return true;
                }
            }

            runnerPerformance = null;
            return false;
        }
    }
}
