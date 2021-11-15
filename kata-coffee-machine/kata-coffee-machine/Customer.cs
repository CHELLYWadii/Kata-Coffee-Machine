using System;
using System.Collections.Generic;
using System.Text;

namespace kata_coffee_machine
{
    /// <summary>
    /// Class that represents a customer
    /// </summary>
    public class Customer
    {
        private Order order { get; set; }
        private double moneyInserted { get; set; }
        public Customer(string drink, int sugar = 0, double money = 0, bool isExtraHot = false)
        {
            order = new Order();
            switch (drink.ToUpper())
            {
                case "COFFEE":
                    order.drink = DrinkType.C;
                    break;
                case "CHOCOLATE":
                    order.drink = DrinkType.H;
                    break;
                case "TEA":
                    order.drink = DrinkType.T;
                    break;
                case "OJ":
                    order.drink = DrinkType.O;
                    break;
                default:
                    order.drink = DrinkType.NONE;
                    break;
            }
            order.sugar = sugar;
            order.isExtraHot = isExtraHot;
            InsertMoney(money);
        }

        public double GetOrderPrice()
        {
            return order.price;
        }

        public void InsertMoney(double money)
        {
            moneyInserted += money;
        }

        private double RemainingToPay()
        {
            return order.price - moneyInserted;
        }

        private bool IsInvalidOrder()
        {
            if (order.sugar > 2)
                return true;
            if (order.drink == DrinkType.NONE)
                return true;
            if (order.drink == DrinkType.O && order.isExtraHot)
                return true;
            return false;
        }

        public string MakeDrinks()
        {
            double moneyToPay = RemainingToPay();
            if (IsInvalidOrder())
                return "M:INVALID ORDER";
            if (moneyToPay > 0)
                return $"M:{moneyToPay} Euros Remaining To Pay";
            string sugar, stick, isExtraHot;
            if (order.sugar == 0)
            {
                sugar = stick = "";
            }
            else
            {
                stick = "0";
                sugar = order.sugar.ToString();
            }
            isExtraHot = order.isExtraHot ? "h" : "";
            return $"{order.drink}{isExtraHot}:{sugar}:{stick}";
        }
    }
}
