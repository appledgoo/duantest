using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameoConsoleApp
{
    class Monster
    {
        private Random rand = new Random();
        public string monsterName { get; set; }
        public int Health { get; set; } = 100;
        public int Atk { get; set; } = 10;

        public Monster(string name)
        {
            monsterName = name;
        }

        public void Attack(Player target)
        {
            int totalDamage = Atk + rand.Next(1, 6);
            target.Health -= totalDamage;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{monsterName} ");
            Console.ResetColor();

            Console.WriteLine($"tan cong {target.playerName} voi {totalDamage} sat thuong!");
        }

        public void Heal(int amount)
        {
            Health += amount;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{monsterName} ");
            Console.ResetColor();

            Console.WriteLine($"hoi {amount} HP!");
        }
        public void DisplayStatus()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{monsterName} - HP: {Health}, ATK: {Atk}");
            Console.ResetColor();
        }

        public void TakeTurn(Player target)
        {
            int action = rand.Next(1, 3);
            if (action == 1)
            {
                Attack(target);
            }
            else
            {
                Heal(15);
            }
        }
    }
}
