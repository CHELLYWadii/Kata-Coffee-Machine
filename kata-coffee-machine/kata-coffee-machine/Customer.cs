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

        private void CheckSugar(int sugar, out string sugarCode, out string stickCode)
        {
            if (sugar == 0)
            {
                sugarCode = stickCode = "";
            }
            else
            {
                stickCode = "0";
                sugarCode = sugar.ToString();
            }
        }

        public string MakeDrinks()
        {
            if (order.sugar > 2 || order.drink == DrinkType.NONE)
                return "M:INVALID ORDER";
            string sugarCode, stickCode;
            CheckSugar(order.sugar, out sugarCode,out stickCode);
            return $"{order.drink}:{sugarCode}:{stickCode}";
        }
    }
}
