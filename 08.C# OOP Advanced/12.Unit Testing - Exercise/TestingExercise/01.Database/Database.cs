using System;

namespace _01.Database
{
    public class Database
    {
        private int[] integers;

        public Database(params int[] integers)
        {
            this.integers = integers;
        }

        public int[] Integers
        {
            get
            {
                return this.integers;

            }
            private set
            {
                if (this.integers.Length >= 16)
                {
                    throw new InvalidOperationException("The array cannot contain more than 16 integers.");
                }

                this.integers = value;
            }
        }

        public void Add(int number)
        {
            if (number == null)
            {
                throw new ArgumentNullException();
            }
            if (this.integers.Length >= 16)
            {
                throw new InvalidOperationException("You cannot add more integers.");

            }

            this.integers[this.integers.Length] = number;
        }

        public void Remove()
        {
            if (this.integers.Length == 0)
            {
                throw new InvalidOperationException("Array is empty.");
            }

            this.integers[this.integers.Length - 1] = 0;
        }

        public int[] Fetch()
        {
            return this.integers;
        }
    }
}