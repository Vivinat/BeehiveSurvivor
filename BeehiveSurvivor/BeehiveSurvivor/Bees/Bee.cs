
using BeehiveSurvivor.Services;

namespace BeehiveSurvivor.Bees;

public abstract class Bee
{
    private string Name { get;}
    public bool IsDead { get; private set; }
    public BeeEnum BeeType { get; private set;}
    protected int Level { get; private set; }

    private readonly EatService _eatService;
    

    protected Bee(string name, int level, BeeEnum beeType, EatService eatService)
    {
        Name = name;
        Level = level;
        BeeType = beeType;
        _eatService = eatService;
    }

    protected void Die(string cause)
    {
        IsDead = true;
        Console.WriteLine($"{Name}, Level{Level} {GetType().Name} {cause}");
    }

    protected void EarnLevel()
    {
        Level++;
    }
    
    public void Eat()
    {
        bool diedFromStarvation = _eatService.Eat();
        if (diedFromStarvation)
        {
            Die(" died of starvation!");
        }

    }
}