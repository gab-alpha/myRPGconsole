class Ability
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Power { get; set; }

    public Ability(string name, string description, int power)
    {
        Name = name;
        Description = description;
        Power = power;
    }

    public void Use(Player player, Enemy enemy)
    {
        enemy.Health -= Power;
        Console.WriteLine($"{player.Name} usou {Name} e causou {Power} de dano ao {enemy.Name}!");
    }
}