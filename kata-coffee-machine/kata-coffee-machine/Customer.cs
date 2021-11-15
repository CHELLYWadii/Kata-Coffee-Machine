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
        public Customer(string drink, int sugar = 0)
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
                default:
                    order.drink = DrinkType.NONE;
                    break;
            }
            order.sugar = sugar;
        }
        public string GetOrder()
        {
            if (order.sugar > 2 || order.drink == DrinkType.NONE)
                return "M:INVALID ORDER";
            string sugar;
            string stick;
            if (order.sugar == 0)
            {
                sugar = stick = "";
            }
            else
            {
                stick = "0";
                sugar = order.sugar.ToString();
            }
            return $"{order.drink}:{sugar}:{stick}";
        }
    }
}
