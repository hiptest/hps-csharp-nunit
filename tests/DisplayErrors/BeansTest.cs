namespace Hiptest.Publisher.Samples.DisplayErrors {

    using System;
    using NUnit.Framework;
    using Hiptest.Publisher.Samples;

    [TestFixture]
    public class BeansTest {

        public Actionwords Actionwords;

        [SetUp]
        protected void SetUp() {
            Actionwords = new Actionwords();

            // Given the coffee machine is started
            Actionwords.TheCoffeeMachineIsStarted();
            // And I handle everything except the beans
            Actionwords.IHandleEverythingExceptTheBeans();
        }

        [Test]
        public void MessageFillBeansIsDisplayedAfter38CoffeesAreTaken() {
            // When I take "38" coffees
            Actionwords.ITakeCoffeeNumberCoffees(38);
            // Then message "Fill beans" should be displayed
            Actionwords.MessageMessageShouldBeDisplayed("Fill beans");
        }

        [Test]
        public void ItIsPossibleToTake40CoffeesBeforeThereIsReallyNoMoreBeans() {
            // Given I take "40" coffees
            Actionwords.ITakeCoffeeNumberCoffees(40);
            // Then coffee should be served
            Actionwords.CoffeeShouldBeServed();
            // When I take a coffee
            Actionwords.ITakeACoffee();
            // Then coffee should not be served
            Actionwords.CoffeeShouldNotBeServed();
            // And message "Fill beans" should be displayed
            Actionwords.MessageMessageShouldBeDisplayed("Fill beans");
        }

        [Test]
        public void AfterAddingBeansTheMessageFillBeansDisappears() {
            // Given I take "40" coffees
            Actionwords.ITakeCoffeeNumberCoffees(40);
            // When I fill the beans tank
            Actionwords.IFillTheBeansTank();
            // Then message "Ready" should be displayed
            Actionwords.MessageMessageShouldBeDisplayed("Ready");
        }
    }
}