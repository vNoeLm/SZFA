using System;
using System.Collections.Generic;
using System.Text;

namespace ZH2
{
    internal class Races
    {
        public RaceResults[] CompletedRaces { get; private set; }
        public Races(RaceResults[] completedRaces)
        {
            CompletedRaces = completedRaces;
        }

        public Time BestPerformance(string name)
        {
            Time best = null;

            foreach (RaceResults race in CompletedRaces)
            {
                foreach (RunnerWithTime runner in race.results)
                {
                    if (runner.Name == name)
                    {
                        if (best == null || runner.Time.CompareTo(best) < 0)
                        {
                            best = runner.Time;
                        }
                        break;
                    }
                }
            }
            return best;
        }

        private RunnerWithTime[] Union(RunnerWithTime[] first, RunnerWithTime[] second)
        {
            RunnerWithTime[] result = new RunnerWithTime[first.Length + second.Length];

            int i = 0;
            int j = 0;
            int k = 0; 

            while (i < first.Length && j < second.Length)
            {
                if (first[i].CompareTo(second[j]) <= 0)
                {
                    result[k++] = first[i++];
                }
                else
                {
                    result[k++] = second[j++];
                }
            }

            while (i < first.Length)
            {
                result[k++] = first[i++];
            }

            while (j < second.Length)
            {
                result[k++] = second[j++];
            }

            return result;
        }

        public RunnerWithTime[] AllBetween(Time lower, Time upper)
        {
            RunnerWithTime[] finalResults = new RunnerWithTime[0];

            foreach (RaceResults race in CompletedRaces)
            {
                int count = 0;
                foreach (var runner in race.results)
                {
                    if (runner.Time.CompareTo(lower) >= 0 && runner.Time.CompareTo(upper) <= 0)
                    {
                        count++;
                    }
                }

                RunnerWithTime[] currentMatch = new RunnerWithTime[count];
                int index = 0;
                foreach (var runner in race.results)
                {
                    if (runner.Time.CompareTo(lower) >= 0 && runner.Time.CompareTo(upper) <= 0)
                    {
                        currentMatch[index++] = runner;
                    }
                }

                finalResults = Union(finalResults, currentMatch);
            }

            return finalResults;
        }
    }
}
