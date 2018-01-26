using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDatabase
{
    using NUnit.Framework.Constraints;
    using _01.Database;

    [TestFixture]
    public class DatabaseTests
    {
        private int[] scores = new int[] {1, 2};
        private Database database;

        [SetUp]
        public void TestUnit()
        {
            this.database = new Database(this.scores);
        }

        [Test]
        public void TestIsCtorInitialiseItemsInArray()
        {
            Assert.AreEqual(2, this.database.Fetch().Length);
        }

        [Test]
        public void TestPropIfItThrewException()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => this.database =
                new Database(new int[] {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}));

            Assert.AreEqual(ex.GetType(), typeof(InvalidOperationException));
        }
    }
}
