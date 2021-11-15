using System;

namespace kata_coffee_machine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kata Coffee Machine Test!");

            var newCustomer = new Customer("tea",1);

            Console.WriteLine(newCustomer.GetOrder());
        }
    }
}
