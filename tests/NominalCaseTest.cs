namespace Hiptest.Publisher.Samples {

    using System;
    using NUnit.Framework;

    [TestFixture]
    public class NominalCaseTest {

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