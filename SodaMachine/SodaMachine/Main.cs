using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Main
    {
        public Customer customer;
        SodaMachine sodaMachine = new SodaMachine();
        Random random = new Random();

        public void StartDay()
        {
            for (int i = 0; i < 20; i++)
            {
                customer = new Customer(random);
                sodaMachine.customer = customer;
                sodaMachine.CheckPurchase(GetCustomerSelection());
            }
        }
        public int GetCustomerSelection()
        {
            Console.Clear();
            Console.WriteLine("You have {0} cents.");
            Console.WriteLine("What soda would you like to buy?");
            Console.WriteLine("/n1. Grape Soda -- 60¢");
            Console.WriteLine("/n1. Orange Soda -- 35¢");
            Console.WriteLine("/n1. Meat Soda -- 6¢");
            switch(Console.ReadLine())
            {
                case "1":
                    return 0;

                case "2":
                    return 1;

                case "3":
                    return 2;

                default:
                    GetCustomerSelection();
                    break;
            }
            return 0;
        }
    }
}
