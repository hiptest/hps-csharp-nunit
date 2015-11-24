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

        public void SimpleUse(string lang, string readyMessage) {
            // Given I start the coffee machine "<lang>"
            Actionwords.IStartTheCoffeeMachine(lang);
            // When I take a coffee
            Actionwords.ITakeACoffee();
            // Then coffee should be served
            Actionwords.CoffeeShouldBeServed();
        }

        [Test]
        public void SimpleUseEnglishUidbe213f3d8bd24c378ed23a494fd92e87() {
            SimpleUse("en", "Ready");
        }

        [Test]
        public void SimpleUseFrenchUid9809634535224858b55ce02196b18482() {
            SimpleUse("fr", "Pret");
        }



        [Test]
        public void FullGroundsDoesNotBlockCoffeeUid1d0d17c3355e4a6eb293ecaa533b21ef() {
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

        [Test]
        public void WaterRunsAwayUidae4016f69b4d4ad7aeba32f710a9b6ab() {
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

        [Test]
        public void BeansRunOutUidf92ba764a84d4779b8ab585148497b89() {
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
        public void MessagesAreBasedOnLanguage(string lang, string readyMessage) {
            // When I start the coffee machine "<lang>"
            Actionwords.IStartTheCoffeeMachine(lang);
            // Then message "<ready_message>" should be displayed
            Actionwords.MessageMessageShouldBeDisplayed(readyMessage);
        }

        [Test]
        public void MessagesAreBasedOnLanguageEnglishUida4f9103300244a8bba72bad87b11abca() {
            MessagesAreBasedOnLanguage("en", "Ready");
        }

        [Test]
        public void MessagesAreBasedOnLanguageFrenchUidb91d9effab85422498638f6e97f357d0() {
            MessagesAreBasedOnLanguage("fr", "Pret");
        }



        [Test]
        public void NoMessagesAreDisplayedWhenMachineIsShutDownUid35f4862793964a0b9090bad7ac1fa0f1() {
            // Given the coffee machine is started
            Actionwords.TheCoffeeMachineIsStarted();
            // When I shutdown the coffee machine
            Actionwords.IShutdownTheCoffeeMachine();
            // Then message "" should be displayed
            Actionwords.MessageMessageShouldBeDisplayed();
        }
    }
}