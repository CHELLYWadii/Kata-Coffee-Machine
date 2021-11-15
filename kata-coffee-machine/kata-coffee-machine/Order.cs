using System;
using System.Collections.Generic;
using System.Text;

namespace kata_coffee_machine
{
    /// <summary>
    /// Class that represents the order of the customer
    /// </summary>
    public class Order
    {
        public DrinkType drink { get; set; }
        public int sugar { get; set; }
        public double price
        {
            get
            {
                switch (drink)
                {
                    case DrinkType.C:
                        return 0.6;
                    case DrinkType.T:
                        return 0.4;
                    case DrinkType.H:
                        return 0.5;
                    default:
                        return 0;
                }
            }
        }
    }
}
