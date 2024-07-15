using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

abstract class Event
{
    public string Description { get; set; }

    public Event(string description)
    {
        Description = description;
    }

    public abstract void Trigger(Player player);
}

class EncounterEvent : Event
{
    public Enemy Enemy { get; set; }

    public EncounterEvent(string description, Enemy enemy) : base(description)
    {
        Enemy = enemy;
    }

    public override void Trigger(Player player)
    {
        Console.WriteLine(Description);
        // Lógica para iniciar um combate com o inimigo
    }
}

class QuestEvent : Event
{
    public string QuestDescription { get; set; }
    public Item Reward { get; set; }

    public QuestEvent(string description, string questDescription, Item reward) : base(description)
    {
        QuestDescription = questDescription;
        Reward = reward;
    }

    public override void Trigger(Player player)
    {
        Console.WriteLine(Description);
        Console.WriteLine(QuestDescription);
        // Lógica para completar a missão
        // Após completar a missão, o jogador recebe a recompensa
        player.AddItem(Reward);
        Console.WriteLine($"Você recebeu {Reward.Name} como recompensa!");
    }
}

class EnvironmentalEvent : Event
{
    public string Effect { get; set; }

    public EnvironmentalEvent(string description, string effect) : base(description)
    {
        Effect = effect;
    }

    public override void Trigger(Player player)
    {
        Console.WriteLine(Description);
        // Lógica para aplicar o efeito ambiental ao jogador
        if (Effect == "chuva")
        {
            Console.WriteLine("Está chovendo, seus movimentos são mais lentos.");
        }
        else if (Effect == "tempestade")
        {
            Console.WriteLine("Uma tempestade se aproxima, você sente um grande poder em volta.");
        }
    }
}

class TrapEvent : Event
{
    public int Damage { get; set; }

    public TrapEvent(string description, int damage) : base(description)
    {
        Damage = damage;
    }

    public override void Trigger(Player player)
    {
        Console.WriteLine(Description);
        player.Health -= Damage;
        Console.WriteLine($"Você caiu em uma armadilha e perdeu {Damage} de saúde!");
    }
}

class NpcEvent : Event
{
    public string NpcName { get; set; }
    public string NpcDialogue { get; set; }
    public Item TradeItem { get; set; }

    public NpcEvent(string description, string npcName, string npcDialogue, Item tradeItem) : base(description)
    {
        NpcName = npcName;
        NpcDialogue = npcDialogue;
        TradeItem = tradeItem;
    }

    public override void Trigger(Player player)
    {
        Console.WriteLine(Description);
        Console.WriteLine($"{NpcName} diz: \"{NpcDialogue}\"");
        Console.WriteLine("Você quer trocar um item? (S/N)");
        string response = Console.ReadLine().ToLower();

        if (response == "s")
        {
            Console.WriteLine("Digite o nome do item que você quer trocar:");
            string itemName = Console.ReadLine();
            Item playerItem = player.Inventory.FirstOrDefault(item => item.Name.ToLower() == itemName.ToLower());

            if (playerItem != null)
            {
                player.Inventory.Remove(playerItem);
                player.AddItem(TradeItem);
                Console.WriteLine($"Você trocou {playerItem.Name} por {TradeItem.Name}.");
            }
            else
            {
                Console.WriteLine("Você não tem esse item.");
            }
        }
        else
        {
            Console.WriteLine($"{NpcName} diz: \"Talvez na próxima vez.\"");
        }
    }
}

class TreasureEvent : Event
{
    public Item Treasure { get; set; }

    public TreasureEvent(string description, Item treasure) : base(description)
    {
        Treasure = treasure;
    }

    public override void Trigger(Player player)
    {
        Console.WriteLine(Description);
        player.AddItem(Treasure);
        Console.WriteLine($"Você encontrou um tesouro! Você recebeu {Treasure.Name}.");
    }
}

class ChallengeEvent : Event
{
    public string Challenge { get; set; }
    public string CorrectAnswer { get; set; }
    public Item Reward { get; set; }

    public ChallengeEvent(string description, string challenge, string correctAnswer, Item reward) : base(description)
    {
        Challenge = challenge;
        CorrectAnswer = correctAnswer;
        Reward = reward;
    }

    public override void Trigger(Player player)
    {
        Console.WriteLine(Description);
        Console.WriteLine(Challenge);
        string playerAnswer = Console.ReadLine();

        if (playerAnswer.ToLower() == CorrectAnswer.ToLower())
        {
            player.AddItem(Reward);
            Console.WriteLine($"Resposta correta! Você recebeu {Reward.Name}.");
        }
        else
        {
            Console.WriteLine("Resposta incorreta. Tente novamente mais tarde.");
        }
    }
}