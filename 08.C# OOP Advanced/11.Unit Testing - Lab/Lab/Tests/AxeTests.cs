using NUnit.Framework;
using System;
using Skeleton.Interfaces;
namespace Tests
{
    [TestFixture]
    public class AxeTests
    {
        private const int AxeAttackPower = 10;
        private const int AxeDurability = 10;
        private const int DummyHealth = 10;
        private const int DummyExperience = 10;
        private IWeapon axe;
        private ITarget dummy;
        [SetUp]
        public void TestUnit()
        {
            this.axe = new Axe(AxeAttackPower,AxeDurability);
            this.dummy = new Dummy(DummyHealth,DummyExperience);
        }
        [Test]
        public void AxeLoseDurabilityAfterAttack()
        {
            this.axe.Attack(this.dummy);

            Assert.AreEqual(9, this.axe.DurabilityPoints,"Axe durability does't change after attack");
        }
        [Test]
        public void BrokenAxeCantAttack()
        {
            this.axe = new Axe(1, 1);

            this.axe.Attack(this.dummy);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => this.axe.Attack(this.dummy));
            Assert.That(ex.Message, Is.EqualTo("Axe is broken"));
        }
    }
}