using GameoConsoleApp;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Nhap ten nguoi choi cua ban:");
        string playerName = Console.ReadLine();
        Player player = new Player(playerName);
        Monster monster = new Monster("Sieu quai vat dang cap ngau loi aura farming sigma male");

        Console.WriteLine($"Chao mung {player.playerName} den voi... {monster.monsterName} da xuat hien!!!!");
        Console.WriteLine($"Danh bai no di {player.playerName}");
        Console.WriteLine();

        while (player.Health > 0 && monster.Health > 0)
        {
            player.DisplayStatus();
            monster.DisplayStatus();
            Console.WriteLine("Chon 1.Tan Cong - 2.Hoi Mau");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                player.Attack(monster);
                if (monster.Health > 0)
                {
                    monster.TakeTurn(player);
                }
            }
            else if (choice == "2")
            {
                player.Heal(20);
                monster.TakeTurn(player);
            }
            else
            {
                Console.WriteLine("Nhap 1 trong 2 de thao tac.");
            }
            Console.WriteLine();
        }

        if (player.Health <= 0)
        {
            Console.WriteLine($"{player.playerName} da bi danh bai -10000 aura!");
        }
        else
        {
            Console.WriteLine($"{monster.monsterName} da bi danh bai mot cach ngau loi!");
        }
    }
}