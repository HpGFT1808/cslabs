using System;
using System.Threading;

public abstract class Mage
{
    public string Name { get; private set; }
    public int MagicLevel { get; private set; }
    public int Health { get; protected set; }

    public Mage(string name, int magicLevel)
    {
        Name = name;
        MagicLevel = magicLevel;
        Health = 100; 
    }

    public abstract void Attack(Mage opponent);
    public abstract void Defend(int damage);
    public bool IsAlive => Health > 0;

    public event EventHandler<MageEventArgs> OnAttack;
    public event EventHandler<MageEventArgs> OnDefend;

    protected virtual void RaiseAttackEvent(MageEventArgs e)
    {
        OnAttack?.Invoke(this, e);
    }

    protected virtual void RaiseDefendEvent(MageEventArgs e)
    {
        OnDefend?.Invoke(this, e);
    }
}

public class MageEventArgs : EventArgs
{
    public string Message { get; private set; }

    public MageEventArgs(string message)
    {
        Message = message;
    }
}

public interface ISpell
{
    void Cast(Mage target);
}

public class FireMage : Mage
{
    public FireMage(string name, int magicLevel) : base(name, magicLevel) { }

    public override void Attack(Mage opponent)
    {
        int damage = 10 * MagicLevel;
        opponent.Defend(damage);
        RaiseAttackEvent(new MageEventArgs($"{Name} casts a fireball at {opponent.Name} dealing {damage} damage."));
    }

    public override void Defend(int damage)
    {
        Health -= damage;
        RaiseDefendEvent(new MageEventArgs($"{Name} takes {damage} damage. Health is now {Health}."));
    }
}

public class WaterMage : Mage
{
    public WaterMage(string name, int magicLevel) : base(name, magicLevel) { }

    public override void Attack(Mage opponent)
    {
        int damage = 8 * MagicLevel;
        opponent.Defend(damage);
        RaiseAttackEvent(new MageEventArgs($"{Name} casts a water blast at {opponent.Name} dealing {damage} damage."));
    }

    public override void Defend(int damage)
    {
        Health -= damage;
        RaiseDefendEvent(new MageEventArgs($"{Name} takes {damage} damage. Health is now {Health}."));
    }
}

public class EarthMage : Mage
{
    public EarthMage(string name, int magicLevel) : base(name, magicLevel) { }

    public override void Attack(Mage opponent)
    {
        int damage = 12 * MagicLevel;
        opponent.Defend(damage);
        RaiseAttackEvent(new MageEventArgs($"{Name} casts an earth spike at {opponent.Name} dealing {damage} damage."));
    }

    public override void Defend(int damage)
    {
        Health -= damage;
        RaiseDefendEvent(new MageEventArgs($"{Name} takes {damage} damage. Health is now {Health}."));
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Choose your mage: 1. Fire Mage 2. Water Mage 3. Earth Mage");
        int choice = int.Parse(Console.ReadLine());

        Mage player;
        switch (choice)
        {
            case 1:
                player = new FireMage("Player", 3);
                break;
            case 2:
                player = new WaterMage("Player", 3);
                break;
            case 3:
                player = new EarthMage("Player", 3);
                break;
            default:
                Console.WriteLine("Invalid choice! Defaulting to Fire Mage.");
                player = new FireMage("Player", 3);
                break;
        }

        Mage bot = new FireMage("Bot", 2);

        player.OnAttack += DisplayEventMessage;
        player.OnDefend += DisplayEventMessage;
        bot.OnAttack += DisplayEventMessage;
        bot.OnDefend += DisplayEventMessage;

        while (player.IsAlive && bot.IsAlive)
        {
            player.Attack(bot);
            Thread.Sleep(2000); 
            if (!bot.IsAlive) break;

            bot.Attack(player);
            Thread.Sleep(2000);
        }

        Console.ForegroundColor = ConsoleColor.Green;
        if (player.IsAlive)
        {
            Console.WriteLine($"{player.Name} wins the battle!");
        }
        else
        {
            Console.WriteLine($"{bot.Name} wins the battle!");
        }
        Console.ResetColor();
    }

    private static void DisplayEventMessage(object sender, MageEventArgs e)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(e.Message);
        Console.ResetColor();
    }
}
