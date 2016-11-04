using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Customer
    {
        List<Coin>[] money = new List<Coin>[4];
        private int startingQuarters;
        private int startingDimes;
        private int startingNickels;
        private int startingPennies;

        public Customer(Random random)
        {
            startingQuarters = random.Next(3);
            startingDimes = random.Next(3);
            startingNickels = random.Next(3);
            startingPennies = random.Next(3);
        }
        public void GenerateMoney()
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
    }
}