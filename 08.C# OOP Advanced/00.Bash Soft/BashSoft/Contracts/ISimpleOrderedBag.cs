namespace BashSoft.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface ISimpleOrderedBag<T> : IEnumerable<T> where T : IComparable<T>
    {
        int Capacity { get; }

        int Size { get; }

        string JoinWith(string joiner);

        bool Remove(T element);

        void Add(T element);

        void AddAll(ICollection<T> collection);
    }
}