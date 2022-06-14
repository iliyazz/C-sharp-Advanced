﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = new List<string>(authors);
        }
        public string Title { get; private set; }
        public int Year { get; private set; }
        public  List<string> Authors { get; private set; }
        public int CompareTo( Book other)
        { 
            int result = Year.CompareTo(other.Year);
            if (result == 0)
            {
                result = Title.CompareTo(other.Title);
            }
            return result;
            
        }
        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }
    }
}
