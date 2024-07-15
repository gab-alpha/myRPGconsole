using System;

abstract class Item
{
    public string Name { get; set; }
    public string Description { get; set; }

    public Item(string name, string description)
    {
        Name = name;
        Description = description;
    }
}

class HealingPotion : Item
{
    public int HealingAmount { get; set; }

    public HealingPotion(string name, string description, int healingAmount) : base(name, description)
    {
        HealingAmount = healingAmount;
    }

    public void Use(Player player)
    {
        player.Health += HealingAmount;
        Console.WriteLine($"{player.Name} usou {Name} e recuperou {HealingAmount} de saúde.");
    }
}

class Weapon : Item
{
    public int AttackPower { get; set; }

    public Weapon(string name, string description, int attackPower) : base(name, description)
    {
        AttackPower = attackPower;
    }

    public void Equip(Player player)
    {
        player.AttackPower += AttackPower;
        Console.WriteLine($"{player.Name} equipou {Name} e ganhou {AttackPower} de poder de ataque.");
    }
}

