namespace BashSoftTesting
{
    using System;
    using System.Collections.Generic;
    using BashSoft.Contracts;
    using BashSoft.DataStructures;
    using NUnit.Framework;

    [TestFixture]
    public class OrderedDataStructureTester
    {
        private ISimpleOrderedBag<string> names;

        [SetUp]
        public void TestUnit()
        {
            this.names = new SimpleSortedList<string>();
        }

        [Test]
        public void TestEmptyCtor()
        {
            Assert.AreEqual(16, this.names.Capacity);
            Assert.AreEqual(0, this.names.Size);
        }

        [Test]
        public void TestCtorWithAllParams()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase, 30);

            Assert.AreEqual(30, this.names.Capacity);
            Assert.AreEqual(0, this.names.Size);
        }

        [Test]
        public void TestCtorWithInitialCapacity()
        {
            this.names = new SimpleSortedList<string>(20);

            Assert.AreEqual(20, this.names.Capacity);
            Assert.AreEqual(0, this.names.Size);
        }

        [Test]
        public void TestCtorWithInitialComparer()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);

            Assert.AreEqual(16, this.names.Capacity);
            Assert.AreEqual(0, this.names.Size);
        }

        [Test]
        public void TestAddIncresesSize()
        {
            this.names.Add("Nasko");

            Assert.AreEqual(1, this.names.Size);
        }

        [Test]
        public void TestAddNullThrowsExeption()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => this.names.Add(null));

            Assert.AreEqual(ex.GetType(), typeof(ArgumentNullException));
        }

        [Test]
        public void TestAddUnsortedDataIsHeldSorted()
        {
            this.names.Add("Rosen");
            this.names.Add("Georgi");
            this.names.Add("Balkan");
            List<string> n = new List<string>();
            foreach (var name in this.names)
            {
                n.Add(name);
            }

            Assert.AreEqual("Balkan Georgi Rosen", string.Join(" ", n));
        }

        [Test]
        public void TestAddingMoreThanInitialCapacity()
        {
            this.names.Add("Rosen");
            this.names.Add("Georgi");
            this.names.Add("Balkan");
            this.names.Add("Rosen1");
            this.names.Add("Georgi1");
            this.names.Add("Balkan1");
            this.names.Add("Rosen2");
            this.names.Add("Georgi2");
            this.names.Add("Balkan2");
            this.names.Add("Rosen3");
            this.names.Add("Georgi3");
            this.names.Add("Balkan3");
            this.names.Add("Rosen4");
            this.names.Add("Georgi4");
            this.names.Add("Balkan4");
            this.names.Add("Rosen5");
            this.names.Add("Georgi5");

            Assert.AreEqual(17, this.names.Size);
            Assert.AreEqual(32, this.names.Capacity);
        }

        [Test]
        public void TestAddingAllFromCollectionIncreasesSize()
        {
            List<string> name = new List<string>() { "Ivan", "Dragan" };

            this.names.AddAll(name);

            Assert.AreEqual(2, this.names.Size);
        }

        [Test]
        public void TestAddingAllFromNullThrowsException()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => this.names.AddAll(null));

            Assert.AreEqual(ex.GetType(), typeof(ArgumentNullException));
        }

        [Test]
        public void TestAddAllKeepsSorted()
        {
            List<string> sorted = new List<string>() { "Rosen", "Georgi", "Balkan" };

            this.names.AddAll(sorted);
            List<string> n = new List<string>();
            foreach (var name in this.names)
            {
                n.Add(name);
            }

            Assert.AreEqual("Balkan Georgi Rosen", string.Join(" ", n));
        }

        [Test]
        public void TestRemoveValidElementDecreasesSize()
        {
            this.names.Add("Pesho");
            this.names.Remove("Pesho");

            Assert.AreEqual(0, this.names.Size);
        }

        [Test]
        public void TestRemoveValidElementRemovesSelectedOne()
        {
            List<string> sorted = new List<string>() { "ivan", "nasko" };

            this.names.AddAll(sorted);
            this.names.Remove("ivan");
            List<string> n = new List<string>();
            foreach (var name in this.names)
            {
                n.Add(name);
            }

            Assert.AreEqual("nasko", string.Join(" ", n));
        }

        [Test]
        public void TestRemovingNullThrowsException()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => this.names.Remove(null));

            Assert.AreEqual(ex.GetType(), typeof(ArgumentNullException));
        }

        [Test]
        public void TestJoinWithNull()
        {
            this.names.Add("Pesho");
            this.names.Add("Stamat");
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => this.names.JoinWith(null));

            Assert.AreEqual(ex.GetType(), typeof(ArgumentNullException));
        }

        [Test]
        public void TestJoinWorksFine()
        {
            this.names.Add("Pesho");
            this.names.Add("Stamat");
            this.names.JoinWith(", ");

            Assert.AreEqual("Pesho, Stamat", this.names.JoinWith(", "));
        }
    }
}
