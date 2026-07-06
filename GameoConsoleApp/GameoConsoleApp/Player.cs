using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameoConsoleApp
{
    class Player
    {
        public string playerName { get; set; }
        public int Health { get; set; } = 100;
        public int Atk { get; set; } = 10;

        public Player(string name)
        {
            playerName = name;
        }
        public void DisplayStatus()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{playerName} - HP: {Health}, ATK: {Atk}");
            Console.ResetColor();
        }
        public void Attack(Monster target)
        {
            target.Health -= Atk;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{playerName} ");
            Console.ResetColor();

            Console.WriteLine($"tan cong {target.monsterName} voi {Atk} sat thuong!");
        }
        public void Heal(int amount)
        {
            Health += amount;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{playerName} ");
            Console.ResetColor();
            Console.WriteLine($"hoi {amount} HP!"); 
        }
    }
}
