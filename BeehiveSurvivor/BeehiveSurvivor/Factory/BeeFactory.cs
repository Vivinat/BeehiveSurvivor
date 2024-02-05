using BeehiveSurvivor.Bees;
using BeehiveSurvivor.Interfaces;
using BeehiveSurvivor.Services;

namespace BeehiveSurvivor.Factory;

public class BeeFactory : IBeeFactory
{
    public Bee CreateBee(string name, BeeEnum beeType)
    {
        switch (beeType)
        {
            case BeeEnum.ForagerBee:
                return new ForagerBee(name, 1, beeType, new EatService(), new ForagerService());
            case BeeEnum.BuilderBee:
                return new BuilderBee(name, 1, beeType, new EatService(), new BuilderService());
            case BeeEnum.WorkerBee:
                return new WorkerBee(name, 1, beeType, new EatService(), new HoneyService());
            default:
                throw new ArgumentException("Invalid bee type.");
        }
    }
}