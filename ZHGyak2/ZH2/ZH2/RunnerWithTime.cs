using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ZH2
{
    internal class RunnerWithTime : IComparable
    {
        public string Name { get; private set; }
        public Time Time { get; private set; }

        public RunnerWithTime(string name, Time time)
        {
            Name = name;
            Time = time;
        }

        public static RunnerWithTime Parse(string input)
        {
            string[] db = input.Split(',');
            Time time = Time.Parse(db[1]);

            return new RunnerWithTime(db[0], time);
        }

        public int CompareTo(object? obj)
        {
            if (obj is RunnerWithTime other)
            {
                int result = this.Time.CompareTo(other.Time);

                if (result == 0)
                {
                    result = this.Name.CompareTo(other.Name);
                }

                return result;
            }

            throw new ArgumentException("Nem RunnerWithTime objektum!");
        }

        public override string ToString()
        {
            return $"{Name} ({Time})";
        }

        public override bool Equals(object? obj)
        {
            if (obj is RunnerWithTime other)
            {
                return (this.Time == other.Time && this.Name == other.Name);
            }
            else
            {
                throw new Exception("Nem RunnerWithTime objektum!");
            }
        }


    }
}
