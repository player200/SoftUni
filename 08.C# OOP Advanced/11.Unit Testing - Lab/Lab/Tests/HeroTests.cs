using NUnit.Framework;
using Skeleton.Interfaces;
using Moq;
namespace Tests
{
    [TestFixture]
    public class HeroTests
    {
        private const int DummyHealth = 0;
        private const int DummyExperience = 20;
        private const string HeroName = "Pesho";
        [Test]
        public void HeroGainsExpAfterKillingATarget()
        {
            Mock<ITarget> fakeTarget = new Mock<ITarget>();
            Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
            Hero hero = new Hero(HeroName, fakeWeapon.Object);
            fakeTarget.Setup(p => p.Health).Returns(DummyHealth);
            fakeTarget.Setup(p => p.GiveExperience()).Returns(DummyExperience);
            fakeTarget.Setup(p => p.IsDead()).Returns(true);

            hero.Attack(fakeTarget.Object);

            Assert.AreEqual(20, hero.Experience,"Hero didn't get any exp.");
        }
    }
}
