namespace Hiptest.Publisher.Samples {

    using System;
    using NUnit.Framework;

    [TestFixture]
    public class ServeCoffeeTest {

        public Actionwords Actionwords;

        [SetUp]
        protected void SetUp() {
            Actionwords = new Actionwords();
        }
        // Well, sometimes, you just get a coffee.
        [Test]
        public void SimpleUse() {
            // Given the coffee machine is started
            Actionwords.TheCoffeeMachineIsStarted();
            // When I take a coffee
            Actionwords.ITakeACoffee();
            // Then coffee should be served
            Actionwords.CoffeeShouldBeServed();
        }
    }
}