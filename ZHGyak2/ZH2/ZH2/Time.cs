using System;
using System.Collections.Generic;
using System.Text;

namespace ZH2
{
    internal class Time : IComparable
    {
        private int hour;
        public int Hour
        {
            get
            {
                return hour;
            }
            set
            {
                if (hour < 0 || hour > 3)
                {
                    throw new TimeException("Hibás Óra!");
                }
                else
                {
                    hour = value;
                }
            }
        }

        private int minute;
        public int Minute
        {
            get
            {
                return minute;
            }
            set
            {
                if (minute < 0 || minute > 59)
                {
                    throw new TimeException("Hibás Perc!");
                }
                else
                {
                    minute = value;
                }
            }
        }

        private int second;
        public int Second
        {
            get
            {
                return second;
            }
            set
            {
                if (second < 0 || second > 59)
                {
                    throw new TimeException("Hibás Másodperc!");
                }
                else
                {
                    second = value;
                }
            }
        }

        public Time(int hour, int minute, int second)
        {
            this.Hour = hour;
            this.Minute = minute;
            this.Second = second;
        }
        public Time(int minute, int second) : this(0, minute, second)
        {
        }

        override public string ToString()
        {
            if (hour >= 1)
            {
                return $"{Hour:D2}:{Minute:D2}:{Second:D2}";
            }
            return $"{Minute:D2}:{Second:D2}";
        }

        public static Time Parse(string time)
        {
            string[] parts = time.Split(':');
            if (parts.Length == 2)
            {
                return new Time(int.Parse(parts[0]), int.Parse(parts[1]));
            }
            else if (parts.Length == 3)
            {
                return new Time(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
            }
            else
            {
                throw new TimeException("Hibás Időformátum!");
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj is Time other)
            {
                return this.Hour == other.Hour && this.Minute == other.Minute && this.Second == other.Second;
            }
            else return false;
        }

        public int CompareTo(object? obj)
        {
            if (obj is Time other)
            {
                int thisTotalSeconds = this.Hour * 3600 + this.Minute * 60 + this.Second;
                int otherTotalSeconds = other.Hour * 3600 + other.Minute * 60 + other.Second;

                return thisTotalSeconds.CompareTo(otherTotalSeconds);
            }
            else
            {
                throw new Exception("Nem Time Objektum!");
            }
        }
    }
}
