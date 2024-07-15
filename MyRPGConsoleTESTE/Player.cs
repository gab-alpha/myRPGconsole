using System;
using System.Collections.Generic;
using System.Linq;

class Player
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int AttackPower { get; set; }
    public List<Item> Inventory { get; set; }
    public List<Ability> Abilities { get; set; }
    public int qntRuns { get; set; }

    public Player(string name, int health, int attackPower, int qntRuns)
    {
        Name = name;
        Health = health;
        AttackPower = attackPower;
        Inventory = new List<Item>();
        Abilities = new List<Ability>();
        this.qntRuns = qntRuns;
    }

    public void Attack(Enemy enemy)
    {
        Console.WriteLine($"{Name} atacou {enemy.Name} e causou {AttackPower} de dano!");
        enemy.Health -= AttackPower;
    }

    public void AddItem(Item item)
    {
        Inventory.Add(item);
        Console.WriteLine($"{Name} obteve {item.Name}!");
    }

    public void UseItem(string itemName)
    {
        Item item = Inventory.FirstOrDefault(i => i.Name.ToLower() == itemName.ToLower());
        if (item != null)
        {
            if (item is HealingPotion potion)
            {
                potion.Use(this);
            }
 
            Inventory.Remove(item);
        }
        else
        {
            Console.WriteLine("Item não encontrado.");
        }
    }

    public void ShowInventory()
    {
        Console.WriteLine("Inventário:");
        foreach (var item in Inventory)
        {
            Console.WriteLine($"{item.Name}: {item.Description}");
        }
    }
}