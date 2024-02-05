using BeehiveSurvivor.Controllers;

namespace BeehiveSurvivor.Bees;

public abstract class Bee
{
    private string Name { get;}
    public bool IsDead { get; private set; }
    public BeeEnum BeeType { get; private set;}
    public int Level { get; private set; }
    

    protected Bee(string name, int level, BeeEnum beeType)
    {
        Name = name;
        Level = level;
        BeeType = beeType;
    }

    protected void Die(string cause)
    {
        IsDead = true;
        Console.WriteLine($"{Name}, {Level} {GetType().Name} {cause}");
    }

    protected void EarnLevel()
    {
        Level++;
    }
    
    public void Eat()
    {
        BeehiveController.StoredHoney--;
        if (BeehiveController.StoredHoney < 0)
        {
            Die(" died of starvation!");
            BeehiveController.StoredHoney = 0;
        }

    }
}