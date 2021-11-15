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
    }
}
