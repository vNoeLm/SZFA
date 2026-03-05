using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTask1
{
    internal class Comic : IComparable<Comic>
    {
        public int PageCount { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }

        public int CompareTo(Comic? other)
        {
            return this.PageCount.CompareTo(other.PageCount);
        }
        override public string ToString()
        {
            return $"Title: {Title}, Author: {Author}, PageCount: {PageCount}";
        }
    }
}
