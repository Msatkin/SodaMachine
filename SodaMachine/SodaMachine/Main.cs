using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Main
    {
        SodaMachine sodaMachine = new SodaMachine();
        Random random = new Random();
        public Customer customer;

        public void StartDay()
        {
            for (int i = 0; i < 20; i++)
            {
                customer = new Customer(random);
                sodaMachine.customer = customer;
                sodaMachine.InsertMoney();
                sodaMachine.CheckPurchase(GetCustomerSelection());
            }
        }
        public int GetCustomerSelection()
        {
            Console.Clear();
            Console.WriteLine("You've inserted {0} cents.", sodaMachine.GetTotalMoney());
            Console.WriteLine("What soda would you like to buy?");
            Console.WriteLine("\n1. Grape Soda -- {0}¢",sodaMachine.sodaPrices[0]);
            Console.WriteLine("2. Orange Soda -- {0}¢", sodaMachine.sodaPrices[1]);
            Console.WriteLine("3. Meat Soda -- {0}¢", sodaMachine.sodaPrices[2]);
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
