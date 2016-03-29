using System.Collections.Generic;

namespace Hiptest.Publisher.Samples {
    using NUnit.Framework;

    public class Actionwords {
        CoffeeMachine Sut = new CoffeeMachine();
        List<string> Handled = new List<string>();

        public void IStartTheCoffeeMachine(string lang = "en") {
            Sut.Start(lang);
        }

        public void IShutdownTheCoffeeMachine() {
            Sut.Stop();
        }

        public void MessageMessageShouldBeDisplayed(string message = "") {
            Assert.AreEqual(message, Sut.Message);
        }

        public void CoffeeShouldBeServed() {
            Assert.IsTrue(Sut.CoffeeServed);
        }

        public void CoffeeShouldNotBeServed() {
            Assert.IsFalse(Sut.CoffeeServed);
        }

        public void ITakeACoffee() {
            Sut.TakeCoffee();
        }

        public void IEmptyTheCoffeeGrounds() {
            Sut.EmptyGrounds();
        }

        public void IFillTheBeansTank() {
            Sut.FillBeans();
        }

        public void IFillTheWaterTank() {
            Sut.FillTank();
        }

        public void ITakeCoffeeNumberCoffees(int coffeeNumber) {
            while ((coffeeNumber > 0)) {
                ITakeACoffee();
                coffeeNumber = coffeeNumber - 1;

                if (Handled.Contains("Water")) {
                    IFillTheWaterTank();
                }

                if (Handled.Contains("Beans")) {
                    IFillTheBeansTank();
                }


                if (Handled.Contains("Grounds")) {
                    IEmptyTheCoffeeGrounds();
                }
            }
        }

        public void TheCoffeeMachineIsStarted() {
            IStartTheCoffeeMachine();
        }

        public void IHandleWaterTank() {
            Handled.Add("Water");
        }

        public void IHandleBeans() {
            Handled.Add("Beans");
        }

        public void IHandleCoffeeGrounds() {
            Handled.Add("Grounds");
        }

        public void IHandleEverythingExceptTheWaterTank() {
            this.IHandleCoffeeGrounds();
            this.IHandleBeans();
        }

        public void IHandleEverythingExceptTheBeans() {
            this.IHandleWaterTank();
            this.IHandleCoffeeGrounds();
        }

        public void IHandleEverythingExceptTheGrounds() {
            this.IHandleWaterTank();
            this.IHandleBeans();
        }

    }
}