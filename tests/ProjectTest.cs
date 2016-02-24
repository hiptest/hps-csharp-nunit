namespace Hiptest.Publisher.Samples {

    using System;
    using NUnit.Framework;

    [TestFixture]
    public class ProjectTest {

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
        // Simple scenario showing that after 50 coffees, the "Fill tank" message is displayed but it is still possible to have coffee until the tank is fully empty.
        [Test]
        public void WaterRunsAway() {
            // Given the coffee machine is started
            Actionwords.TheCoffeeMachineIsStarted();
            // When fifty coffees have been taken without filling the tank
            Actionwords.FiftyCoffeesHaveBeenTakenWithoutFillingTheTank();
            // Then message "Fill tank" should be displayed
            Actionwords.MessageMessageShouldBeDisplayed("Fill tank");
            // When I take a coffee
            Actionwords.ITakeACoffee();
            // Then coffee should be served
            Actionwords.CoffeeShouldBeServed();
            // When I take "10" coffees
            Actionwords.ITakeCoffeeNumberCoffees(10);
            // Then coffee should not be served
            Actionwords.CoffeeShouldNotBeServed();
            // And message "Fill tank" should be displayed
            Actionwords.MessageMessageShouldBeDisplayed("Fill tank");
            // When I fill the water tank
            Actionwords.IFillTheWaterTank();
            // Then message "Ready" should be displayed
            Actionwords.MessageMessageShouldBeDisplayed("Ready");
        }
        // Simple scenario showing that after 38 coffees, the message "Fill beans" is displayed but it is possible to take two coffees until there is no more beans.
        [Test]
        public void BeansRunOut() {
            // Given the coffee machine is started
            Actionwords.TheCoffeeMachineIsStarted();
            // When thirty eight coffees are taken without filling beans
            Actionwords.ThirtyEightCoffeesAreTakenWithoutFillingBeans();
            // Then coffee should be served
            Actionwords.CoffeeShouldBeServed();
            // And message "Fill beans" should be displayed
            Actionwords.MessageMessageShouldBeDisplayed("Fill beans");
            // When I take "2" coffees
            Actionwords.ITakeCoffeeNumberCoffees(2);
            // Then coffee should be served
            Actionwords.CoffeeShouldBeServed();
            // And message "Fill beans" should be displayed
            Actionwords.MessageMessageShouldBeDisplayed("Fill beans");
            // When I take a coffee
            Actionwords.ITakeACoffee();
            // Then coffee should not be served
            Actionwords.CoffeeShouldNotBeServed();
        }
        // You keep getting coffee even if the "Empty grounds" message is displayed. That said it's not a fantastic idea, you'll get ground everywhere when you'll decide to empty it.
        [Test]
        public void FullGroundsDoesNotBlockCoffee() {
            // Given the coffee machine is started
            Actionwords.TheCoffeeMachineIsStarted();
            // When I take "29" coffees
            Actionwords.ITakeCoffeeNumberCoffees(29);
            // Then message "Ready" should be displayed
            Actionwords.MessageMessageShouldBeDisplayed("Ready");
            // When I take a coffee
            Actionwords.ITakeACoffee();
            // Then coffee should be served
            Actionwords.CoffeeShouldBeServed();
            // And message "Empty grounds" should be displayed
            Actionwords.MessageMessageShouldBeDisplayed("Empty grounds");
            // When I fill the water tank
            Actionwords.IFillTheWaterTank();
            // And I fill the beans tank
            Actionwords.IFillTheBeansTank();
            // And I take "20" coffees
            Actionwords.ITakeCoffeeNumberCoffees(20);
            // Then coffee should be served
            Actionwords.CoffeeShouldBeServed();
            // And message "Empty grounds" should be displayed
            Actionwords.MessageMessageShouldBeDisplayed("Empty grounds");
        }
        public void MessagesAreBasedOnLanguage(string lang, string readyMessage) {
            // When I start the coffee machine "<lang>"
            Actionwords.IStartTheCoffeeMachine(lang);
            // Then message "<ready_message>" should be displayed
            Actionwords.MessageMessageShouldBeDisplayed(readyMessage);
        }

        [Test]
        public void MessagesAreBasedOnLanguageEnglish() {
            MessagesAreBasedOnLanguage("en", "Ready");
        }

        [Test]
        public void MessagesAreBasedOnLanguageFrench() {
            MessagesAreBasedOnLanguage("fr", "Pret");
        }



        [Test]
        public void NoMessagesAreDisplayedWhenMachineIsShutDown() {
            // Given the coffee machine is started
            Actionwords.TheCoffeeMachineIsStarted();
            // When I shutdown the coffee machine
            Actionwords.IShutdownTheCoffeeMachine();
            // Then message "" should be displayed
            Actionwords.MessageMessageShouldBeDisplayed();
        }
    }
}