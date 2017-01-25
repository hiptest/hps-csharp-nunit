namespace Hiptest.Publisher.Samples {

    using System;
    using NUnit.Framework;

    [TestFixture]
    public class CanBeConfiguredTest {

        public Actionwords Actionwords;

        [SetUp]
        protected void SetUp() {
            Actionwords = new Actionwords();
        }

        [Test]
        public void DisplaySettings() {
            // Given the coffee machine is started
            Actionwords.TheCoffeeMachineIsStarted();
            // When I switch to settings mode
            Actionwords.ISwitchToSettingsMode();
            // Then displayed message is:
            Actionwords.DisplayedMessageIs("Settings:\n - 1: water hardness\n - 2: grinder");
        }

        [Test]
        public void DefaultSettings() {
            // Given the coffee machine is started
            Actionwords.TheCoffeeMachineIsStarted();
            // When I switch to settings mode
            Actionwords.ISwitchToSettingsMode();
            // Then settings should be: "| water hardness | 2      |
            // | grinder        | medium |"
            Actionwords.SettingsShouldBe("| water hardness | 2      |\n| grinder        | medium |");
        }
    }
}