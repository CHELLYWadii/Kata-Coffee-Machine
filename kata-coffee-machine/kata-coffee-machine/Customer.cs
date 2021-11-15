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
        public Customer(string drink, int sugar = 0, double money = 0)
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

        private double DeptToPay()
        {
            double dept = Math.Round((order.price - moneyInserted), 3);
            return dept > 0 ? dept : 0;
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
            double moneyToPay = DeptToPay();
            if (order.sugar > 2 || order.drink == DrinkType.NONE)
                return "M:INVALID ORDER";
            if (moneyToPay > 0)
                return $"M:{moneyToPay} Euros Remaining To Pay";

            string sugarCode, stickCode;
            CheckSugar(order.sugar, out sugarCode,out stickCode);
            return $"{order.drink}:{sugarCode}:{stickCode}";
        }
    }
}
