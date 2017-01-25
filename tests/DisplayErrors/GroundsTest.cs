namespace Hiptest.Publisher.Samples.DisplayErrors {

    using System;
    using NUnit.Framework;
    using Hiptest.Publisher.Samples;

    [TestFixture]
    public class GroundsTest {

        public Actionwords Actionwords;

        [SetUp]
        protected void SetUp() {
            Actionwords = new Actionwords();

            // Given the coffee machine is started
            Actionwords.TheCoffeeMachineIsStarted();
            // And I handle everything except the grounds
            Actionwords.IHandleEverythingExceptTheGrounds();
        }

        [Test]
        public void MessageEmptyGroundsIsDisplayedAfter30CoffeesAreTaken() {
            // When I take "30" coffees
            Actionwords.ITakeCoffeeNumberCoffees(30);
            // Then message "Empty grounds" should be displayed
            Actionwords.MessageMessageShouldBeDisplayed("Empty grounds");
        }

        [Test]
        public void WhenTheGroundsAreEmptiedMessageIsRemoved() {
            // Given I take "30" coffees
            Actionwords.ITakeCoffeeNumberCoffees(30);
            // When I empty the coffee grounds
            Actionwords.IEmptyTheCoffeeGrounds();
            // Then message "Ready" should be displayed
            Actionwords.MessageMessageShouldBeDisplayed("Ready");
        }
    }
}