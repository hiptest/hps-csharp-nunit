namespace Hiptest.Publisher.Samples {

    using System;
    using NUnit.Framework;

    [TestFixture]
    public class SupportInternationalisationTest {

        public Actionwords Actionwords;

        [SetUp]
        protected void SetUp() {
            Actionwords = new Actionwords();
        }

        [Test]
        public void NoMessagesAreDisplayedWhenMachineIsShutDown() {
            // Given the coffee machine is started
            Actionwords.TheCoffeeMachineIsStarted();
            // When I shutdown the coffee machine
            Actionwords.IShutdownTheCoffeeMachine();
            // Then message "" should be displayed
            Actionwords.MessageMessageShouldBeDisplayed("");
        }
        public void MessagesAreBasedOnLanguage(string language, string readyMessage) {
            // Well, sometimes, you just get a coffee.
            // When I start the coffee machine using language "<language>"
            Actionwords.IStartTheCoffeeMachineUsingLanguageLang(language);
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
    }
}