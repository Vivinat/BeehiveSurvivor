using BeehiveSurvivor.Controllers;
using BeehiveSurvivor.Interfaces;
using BeehiveSurvivor.Bees;

namespace BeehiveSurvivor.Services;

public class CasualtiesService : ICasualty
{
    public void CalculateCasualties()
    {
        for (int i = BeehiveController.Beehive.Count - 1; i >= 0; i--)
        {
            Bee deadBee = BeehiveController.Beehive[i];
            if (deadBee.IsDead)
            {
                BeehiveController.Beehive.Remove(deadBee);
            }
        }
    }

    public bool IsQueenDead()
    {
        if (BeehiveController.Beehive.FindIndex(b=> b.BeeType == BeeEnum.QueenBee) == -1)
        {
            return true;
        }
        return false;
    }
}