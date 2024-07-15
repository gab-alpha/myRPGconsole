using System;

class LootItem
{
    public Item Item { get; set; }
    public double DropChance { get; set; }

    public LootItem(Item item, double dropChance)
    {
        Item = item;
        DropChance = dropChance;
    }
}