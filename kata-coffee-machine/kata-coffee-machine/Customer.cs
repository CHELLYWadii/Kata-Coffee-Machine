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
            order.drink = GetDrinkType(drink);
            order.sugar = sugar;
            InsertMoney(money);
        }

        private DrinkType GetDrinkType(string drink)
        {
            switch (drink.ToUpper())
            {
                case "COFFEE":
                    return order.drink = DrinkType.C;
                case "CHOCOLATE":
                    return order.drink = DrinkType.H;
                case "TEA":
                    return order.drink = DrinkType.T;
                default:
                    return order.drink = DrinkType.NONE;
            }
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

        private bool HasInvalidOrder()
        {
            if (order.sugar > 2)
                return true;
            if (order.drink == DrinkType.NONE)
                return true;
            return false;
        }

        public string MakeDrinks()
        {
            if (HasInvalidOrder())
                return "M:INVALID ORDER";
            double moneyToPay = DeptToPay();
            if (moneyToPay > 0)
                return $"M:{moneyToPay} Euros Remaining To Pay";

            string sugarCode, stickCode;
            CheckSugar(order.sugar, out sugarCode,out stickCode);
            return $"{order.drink}:{sugarCode}:{stickCode}";
        }
    }
}
