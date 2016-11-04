using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class SodaMachine
    {
        List<Coin>[] money = new List<Coin>[4];
        List<Soda>[] inventory = new List<Soda>[3];
        public Customer customer;
        private int startingQuarters = 20;
        private int startingDimes = 10;
        private int startingNickels = 20;
        private int startingPennies = 50;
        private int startingStock = 12;
        private double[] sodaPrices = new double[3] { .6, .35, .06 };
        
        public SodaMachine()
        {
            GenerateStartingMoney();
            GenerateStartingInventory();
        }
        public void GenerateStartingMoney()
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
        public void GenerateStartingInventory()
        {
            for (int i = 0; i < startingStock; i++)
            {
                inventory[0].Add(new GrapeSoda());
                inventory[0].Add(new OrangeSoda());
                inventory[0].Add(new MeatSoda());
            }
        }
        public void CheckPurchase(int selection)
        {

        }
    }
}
