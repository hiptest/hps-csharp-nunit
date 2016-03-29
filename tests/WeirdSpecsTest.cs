namespace Hiptest.Publisher.Samples {

    using System;
    using NUnit.Framework;

    [TestFixture]
    public class WeirdSpecsTest {

        public Actionwords Actionwords;

        [SetUp]
        protected void SetUp() {
            Actionwords = new Actionwords();
        }
        // You keep getting coffee even if the "Empty grounds" message is displayed. That said it's not a fantastic idea, you'll get ground everywhere when you'll decide to empty it.
        [Test]
        public void FullGroundsDoesNotBlockCoffee() {
            // Given the coffee machine is started
            Actionwords.TheCoffeeMachineIsStarted();
            // And I handle everything except the grounds
            Actionwords.IHandleEverythingExceptTheGrounds();
            // When I take "50" coffees
            Actionwords.ITakeCoffeeNumberCoffees(50);
            // Then message "Empty grounds" should be displayed
            Actionwords.MessageMessageShouldBeDisplayed("Empty grounds");
            // And coffee should be served
            Actionwords.CoffeeShouldBeServed();
        }
    }
}