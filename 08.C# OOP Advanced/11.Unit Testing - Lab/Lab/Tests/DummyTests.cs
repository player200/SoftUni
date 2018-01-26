using System;
using NUnit.Framework;
using Skeleton.Interfaces;
namespace Tests
{
    [TestFixture]
    public class DummyTests
    {
        private const int DummyHealth = 10;
        private const int DummyExperience = 10;
        private const int AxeAttackPower = 10;
        private const int AxeDurability = 10;
        private ITarget dummy;
        private IWeapon axe;
        [SetUp]
        public void TestUnit()
        {
            this.dummy = new Dummy(DummyHealth,DummyExperience);
            this.axe = new Axe(AxeAttackPower,AxeDurability);
        }
        [Test]
        public void DummyLoseHealthWhenAttacked()
        {
            this.axe = new Axe(9, AxeDurability);

            this.dummy.TakeAttack(this.axe.AttackPoints);

            Assert.AreEqual(1, this.dummy.Health, "Dummy health does't change after attack");
        }
        [Test]
        public void DeadDummyExeption()
        {
            this.dummy.TakeAttack(this.axe.AttackPoints);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => this.dummy.TakeAttack(this.axe.AttackPoints));
            Assert.That(ex.Message, Is.EqualTo("Dummy is dead."));
        }
        [Test]
        public void DummyGivesExperience()
        {
            this.dummy.TakeAttack(this.axe.AttackPoints);
            
            Assert.AreEqual(10, this.dummy.GiveExperience(),"Dummy is dead, you got 10 exp.");
        }
        [Test]
        public void DummyIsNotGivingExperience()
        {
            this.axe = new Axe(9, AxeDurability);

            this.dummy.TakeAttack(this.axe.AttackPoints);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => this.dummy.GiveExperience());
            Assert.That(ex.Message, Is.EqualTo("Target is not dead."));
        }
    }
}
