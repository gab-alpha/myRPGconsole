using System;
using System.Collections.Generic;

class Enemy
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int AttackPower { get; set; }
    public List<LootItem> LootTable { get; set; }

    public Enemy(string name, int health, int attackPower, List<LootItem> lootTable)
    {
        Name = name;
        Health = health;
        AttackPower = attackPower;
        LootTable = lootTable;
    }

    public void Attack(Player player)
    {
        Console.WriteLine($"{Name} atacou {player.Name} e causou {AttackPower} de dano!");
        player.Health -= AttackPower;
    }
}

class Goblin : Enemy
{
    public Goblin() : base("Goblin", 40, 6, new List<LootItem>
    {
        new LootItem(new HealingPotion("Poção de Cura", "Recupera 10 de saúde.", 10), 0.5)
    })
    { }
}

class Orc : Enemy
{
    public Orc() : base("Orc", 65, 12, new List<LootItem>
    {
        new LootItem(new HealingPotion("Poção de Cura", "Recupera 20 de saúde.", 20), 0.3),
        new LootItem(new Weapon("Machado de Orc", "Um machado pesado usado por Orcs.", 15), 0.1)
    })
    { }
}
class Urso : Enemy
{
    public Urso() : base("Urso", 95, 25, new List<LootItem>
    {
        new LootItem(new HealingPotion("Poção de Cura", "Recupera 20 de saúde.", 20), 0.3),
    })
    { }
}

class Dragon : Enemy
{
    public Dragon() : base("Dragão", 3000, 250, new List<LootItem>
    {
        new LootItem(new HealingPotion("Poção de Cura", "Recupera 50 de saúde.", 50), 0.2),
        //new LootItem(new Armor ("Uma armadura feito com as chamas e escama de um dragão", 500) 1.0),
        new LootItem(new Weapon("Dragon Slayer", "Uma espada forjada no fogo de um dragão.", 25), 1.0)
    })
    { }
}

class Skeleton : Enemy
{
    public Skeleton() : base("Esqueleto", 60, 10, new List<LootItem>
    {
        new LootItem(new HealingPotion("Poção de Cura", "Recupera 20 de saúde.", 20), 0.5),
        new LootItem(new Weapon("Espada Enferrujada", "Uma espada velha e enferrujada.", 8), 0.15),
        //new LootItem(new Armor("Armadura de Ossos", "Uma armadura feita de ossos.", 5), 0.1)
    })
    { }
}

class Zombie : Enemy
{
    public Zombie() : base("Zumbi", 80, 8, new List<LootItem>
    {
        new LootItem(new HealingPotion("Poção de Cura", "Recupera 15 de saúde.", 15), 0.4),
    })
    { }
}

class Mage : Enemy
{
    public Mage() : base("Mago", 70, 25, new List<LootItem>
    {
        new LootItem(new HealingPotion("Poção de Cura", "Recupera 25 de saúde.", 25), 0.35),
        new LootItem(new Weapon("Cajado Mágico", "Um cajado imbuído com poder arcano.", 20), 0.1),
        //new LootItem(new MagicRing("Anel Místico", "Um anel com poder mágico.", 10), 0.05)
    })
    { }
}