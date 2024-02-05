using BeehiveSurvivor.Bees;

namespace BeehiveSurvivor.Interfaces;

public interface IBeeFactory
{
    Bee CreateBee(string name, BeeEnum beeType);
}