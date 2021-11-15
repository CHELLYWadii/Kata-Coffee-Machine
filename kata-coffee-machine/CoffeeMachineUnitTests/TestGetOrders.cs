using kata_coffee_machine;
using NUnit.Framework;

namespace CoffeeMachineUnitTests
{
    public class TestGetOrders
    {
        public void TestDrink(string drink)
        {
            string drinkType;
            switch (drink.ToLower())
            {
                case "coffee":
                    drinkType = "C";
                    break;
                case "tea":
                    drinkType = "T";
                    break;
                case "chocolate":
                    drinkType = "H";
                    break;
                case "oj":
                    drinkType = "O";
                    break;
                default:
                    drinkType = "";
                    break;
            }
            var customer = new Customer(drink, 0, 1, false);
            Assert.AreEqual(customer.GetOrderCommand(), $"{drinkType}::");
            customer = new Customer(drink, 1, 1, false);
            Assert.AreEqual(customer.GetOrderCommand(), $"{drinkType}:1:0");
            if (drinkType != "O")
            {
                customer = new Customer(drink, 0, 1, true);
                Assert.AreEqual(customer.GetOrderCommand(), $"{drinkType}h::");
                customer = new Customer(drink, 1, 1, true);
                Assert.AreEqual(customer.GetOrderCommand(), $"{drinkType}h:1:0");
            }
            customer = new Customer(drink, 3, 1, false);
            Assert.AreEqual(customer.GetOrderCommand(), "M:INVALID ORDER");
            customer = new Customer(drink);
            var remainingToPay = -1 * customer.GetOrderPrice();
            Assert.AreNotEqual(customer.GetOrderCommand(), $"M:{remainingToPay} Euros Remaining To Pay");
        }

        [Test]
        public void TestGetCoffee()
        {
            TestDrink("coffee");
        }
        [Test]
        public void TestGetChocolate()
        {
            TestDrink("chocolate");
        }
        [Test]
        public void TestGetTea()
        {
            TestDrink("tea");
        }
        [Test]
        public void TestGetOrangeJuice()
        {
            TestDrink("oj");
        }
        [Test]
        public void TestInvalidOrder()
        {
            var customer = new Customer("Non Valid Drink");
            Assert.AreEqual(customer.GetOrderCommand(), "M:INVALID ORDER");
            customer = new Customer("oj", 0, 1, true);
            Assert.AreEqual(customer.GetOrderCommand(), "M:INVALID ORDER");
        }

    }
}