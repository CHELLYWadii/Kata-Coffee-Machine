using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
            order.drink = GetDrinkType(drink);
            order.sugar = sugar;
            order.isExtraHot = isExtraHot;
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
                case "OJ":
                    return order.drink = DrinkType.O;
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

        private bool HasInvalidOrder()
        {
            if (order.sugar > 2)
                return true;
            if (order.drink == DrinkType.NONE)
                return true;
            if (order.drink == DrinkType.O && order.isExtraHot)
                return true;
            return false;
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

        private string GetExtraHotCode(bool extraHot)
        {
            return extraHot ? "h" : "";
        }

        public string GetOrderCommand()
        {
            if (HasInvalidOrder())
                return "M:INVALID ORDER";
            double moneyToPay = DeptToPay();
            if (moneyToPay > 0)
                return $"M:{moneyToPay} Euros Remaining To Pay";

            string sugarCode, stickCode, isExtraHotCode;
            CheckSugar(order.sugar, out sugarCode, out stickCode);
            isExtraHotCode = GetExtraHotCode(order.isExtraHot);
            return $"{order.drink}{isExtraHotCode}:{sugarCode}:{stickCode}";
        }

        public void SendCoffeeMakerCommand()
        {
            Console.WriteLine(GetOrderCommand());
        }
    }
}
