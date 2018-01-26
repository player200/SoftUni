﻿using System.Collections.Generic;
using System.Collections;
public class Library : IEnumerable<Book>
{
    private SortedSet<Book> books;
    public Library(params Book[] books)
    {
        this.books = new SortedSet<Book>(books,new BookComparator());
    }
    public IEnumerator<Book> GetEnumerator()
    {
        return this.books.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    private class LibraryIterator : IEnumerator<Book>
    {
        private readonly List<Book> books;
        private int currentIndex;
        public LibraryIterator(IEnumerable<Book> books)
        {
            this.Reset();
            this.books = new List<Book>(books);
        }
        public void Dispose()
        {
        }
        public bool MoveNext()
        {
            return ++currentIndex < this.books.Count;
        }
        public void Reset()
        {
            this.currentIndex = -1;
        }
        public Book Current
        {
            get { return this.books[currentIndex]; }
        }
        object IEnumerator.Current
        {
            get { return this.Current; }
        }
    }
}