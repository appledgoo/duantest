using System;
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
        Console.WriteLine($"{playerName} - HP: {Health}, ATK: {Atk}");
    }
    public void Attack(Monster target)
    {
        target.Health -= Atk;
        Console.WriteLine($"{playerName} tan cong {target.monsterName} voi {Atk} sat thuong!");
    }
    public void Heal(int amount)
    {
        Health += amount;
        Console.WriteLine($"{playerName} hoi {amount} HP!");
    }
}

class Monster {
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
        target.Health -= Atk + rand.Next(1, 6);
        Console.WriteLine($"{monsterName} tan cong {target.playerName} voi {Atk} sat thuong!");
    }
    public void Heal(int amount)
    {
        Health += amount;
        Console.WriteLine($"{monsterName} hoi {amount} HP!");
    }
    public void DisplayStatus()
    {
        Console.WriteLine($"{monsterName} - HP: {Health}, ATK: {Atk}");
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

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Nhap ten nguoi choi cua ban:");
        string playerName = Console.ReadLine();
        Player player = new Player(playerName);
        Monster monster = new Monster("Sieu quai vat dang cap ngau loi aura farming sigma male");

        Console.WriteLine($"Chao mung {player.playerName} den voi... {monster.monsterName} da xuat hien!!!!");
        Console.WriteLine($"Danh bai no di {player.playerName}");

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
            Console.WriteLine($"{monster.monsterName} da bi danh bai mot cach ngau loi" +
                $"!");
        }
    }
}