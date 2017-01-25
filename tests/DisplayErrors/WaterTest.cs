namespace Hiptest.Publisher.Samples.DisplayErrors {

    using System;
    using NUnit.Framework;
    using Hiptest.Publisher.Samples;

    [TestFixture]
    public class WaterTest {

        public Actionwords Actionwords;

        [SetUp]
        protected void SetUp() {
            Actionwords = new Actionwords();

            // Given the coffee machine is started
            Actionwords.TheCoffeeMachineIsStarted();
            // And I handle everything except the water tank
            Actionwords.IHandleEverythingExceptTheWaterTank();
        }

        [Test]
        public void MessageFillWaterTankIsDisplayedAfter50CoffeesAreTaken() {
            // When I take "50" coffees
            Actionwords.ITakeCoffeeNumberCoffees(50);
            // Then message "Fill tank" should be displayed
            Actionwords.MessageMessageShouldBeDisplayed("Fill tank");
        }

        [Test]
        public void ItIsPossibleToTake10CoffeesAfterTheMessageFillWaterTankIsDisplayed() {
            // Given I take "60" coffees
            Actionwords.ITakeCoffeeNumberCoffees(60);
            // Then coffee should be served
            Actionwords.CoffeeShouldBeServed();
            // When I take a coffee
            Actionwords.ITakeACoffee();
            // Then coffee should not be served
            Actionwords.CoffeeShouldNotBeServed();
        }

        [Test]
        public void WhenTheWaterTankIsFilledTheMessageDisappears() {
            // Given I take "55" coffees
            Actionwords.ITakeCoffeeNumberCoffees(55);
            // When I fill the water tank
            Actionwords.IFillTheWaterTank();
            // Then message "Ready" should be displayed
            Actionwords.MessageMessageShouldBeDisplayed("Ready");
        }
    }
}