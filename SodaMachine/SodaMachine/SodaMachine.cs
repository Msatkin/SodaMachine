using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class SodaMachine
    {
        List<Coin>[] money = new List<Coin>[4] { new List<Coin>(), new List<Coin>(), new List<Coin>(), new List<Coin>() };
        List<Coin>[] insertedMoney = new List<Coin>[4] { new List<Coin>(), new List<Coin>(), new List<Coin>(), new List<Coin>() };
        List<Soda>[] inventory = new List<Soda>[3] { new List<Soda>(), new List<Soda>(), new List<Soda>() };
        public decimal[] sodaPrices = new decimal[3] { .6m, .35m, .06m };
        public Customer customer;
        private int startingQuarters = 20;
        private int startingDimes = 10;
        private int startingNickels = 20;
        private int startingPennies = 50;
        private int startingStock = 12;
        
        public SodaMachine()
        {
            GenerateStartingMoney();
            GenerateStartingInventory();
        }
        private void GenerateStartingMoney()
        {
            for (int i = 0; i < startingQuarters; i++)
            {
                money[0].Add(new Quarter());
            }
            for (int i = 0; i < startingDimes; i++)
            {
                money[1].Add(new Dime());
            }
            for (int i = 0; i < startingNickels; i++)
            {
                money[2].Add(new Nickel());
            }
            for (int i = 0; i < startingPennies; i++)
            {
                money[3].Add(new Penny());
            }
        }
        private void GenerateStartingInventory()
        {
            for (int i = 0; i < startingStock; i++)
            {
                inventory[0].Add(new GrapeSoda());
                inventory[1].Add(new OrangeSoda());
                inventory[2].Add(new MeatSoda());
            }
        }
        public void CheckPurchase(int selection)
        {
            Console.Clear();
            decimal totalMoney = GetTotalMoney();
            if (sodaPrices[selection] <= totalMoney && inventory[selection].Count > 0 && CheckChange(totalMoney - sodaPrices[selection]))
            {
                DispenseSoda(selection, totalMoney);
            }
            else
            {
                GiveChange(totalMoney);
            }
            insertedMoney = new List<Coin>[4] { new List<Coin>(), new List<Coin>(), new List<Coin>(), new List<Coin>() };
        }
        public void InsertMoney()
        {
            for (int i = 0; i < customer.money.Length; i++)
            {
                foreach (Coin coin in customer.money[i])
                {
                    insertedMoney[i].Add(coin);
                    money[i].Add(coin);
                }

                int numberOfCoins = customer.money[i].Count;

                for (int j = 0; j < numberOfCoins; j++)
                {
                    customer.money[i].RemoveAt(0);
                }
            }
        }
        public decimal GetTotalMoney()
        {
            decimal totalMoney = 0;
            for (int i = 0; i < insertedMoney.Length; i++)
            {
                foreach (Coin coin in insertedMoney[i])
                {
                    totalMoney += coin.coinValue;
                }
            }
            return totalMoney;
        }
        private void DispenseSoda(int selection, decimal totalMoney)
        {
            customer.soda = inventory[selection][0];
            inventory[selection].RemoveAt(0);
            Console.WriteLine("You got your soda!");
            decimal change = totalMoney - sodaPrices[selection];
            GiveChange(change);
        }
        private void GiveChange(decimal change)
        {
            decimal changeToRecieve = change;
            while (change >= .25m && money[0].Count > 0)
            {
                customer.money[0].Add(money[0][0]);
                money[0].RemoveAt(0);
                change -= .25m;
            }
            while (change >= .10m && money[1].Count > 0)
            {
                customer.money[1].Add(money[1][0]);
                money[1].RemoveAt(0);
                change -= .10m;
            }
            while (change >= .05m && money[2].Count > 0)
            {
                customer.money[2].Add(money[2][0]);
                money[2].RemoveAt(0);
                change -= .05m;
            }
            while (change >= .01m && money[3].Count > 0)
            {
                customer.money[3].Add(money[3][0]);
                money[3].RemoveAt(0);
                change -= .01m;
            }
            DisplayChangeRecieved(changeToRecieve);
        }
        private bool CheckChange(decimal change)
        {
            while (change >= .25m && money[0].Count > 0)
            {
                change -= .25m;
            }
            while (change >= .10m && money[1].Count > 0)
            {
                change -= .10m;
            }
            while (change >= .05m && money[2].Count > 0)
            {
                change -= .05m;
            }
            while (change >= .01m && money[3].Count > 0)
            {
                change -= .01m;
            }
            return (change == 0);
        }
        private void DisplayChangeRecieved(decimal change)
        {
            if (change > 0)
            {
                Console.WriteLine("You've recieved {0}¢ back.\n",change);
                Console.WriteLine("You got {0} quarters back.",customer.money[0].Count);
                Console.WriteLine("You got {0} dimes back.", customer.money[1].Count);
                Console.WriteLine("You got {0} nickels back.", customer.money[2].Count);
                Console.WriteLine("You got {0} pennies back.", customer.money[3].Count);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("You didn't recieve any change.");
            }
        }
    }
}