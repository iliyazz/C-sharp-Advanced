using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private  List<Book> books;
        public Library(params Book[] books)
        {
            this.books = new List<Book> (books);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            var bookList = this.books.OrderBy(x => x).ToList();
            for (int i = 0; i < bookList.Count; i++)
            {
                yield return bookList[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int currentIndex;
            public LibraryIterator(IEnumerable<Book> books)
            {
                this.books = books.ToList();
                this.Reset();
            }

            public void Dispose() { }

            public bool MoveNext() => ++this.currentIndex < this.books.Count;

            public void Reset() => this.currentIndex = -1;
            public Book Current => this.books[this.currentIndex];
            object IEnumerator.Current => this.Current;

        }
    }
}
