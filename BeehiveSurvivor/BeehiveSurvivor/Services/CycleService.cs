using BeehiveSurvivor.Controllers;
using BeehiveSurvivor.Interfaces;
using BeehiveSurvivor.Bees;

namespace BeehiveSurvivor.Services;

public class CycleService : ICycle
{
    public void WorkCycle()
    {
        for (int i = BeehiveController.Beehive.Count - 1; i >= 0; i--)
        {
            switch (BeehiveController.Beehive[i].BeeType)
            {
                case BeeEnum.ForagerBee:
                    ((ForagerBee)BeehiveController.Beehive[i]).Forage();
                    break;
                case BeeEnum.BuilderBee:
                    ((BuilderBee)BeehiveController.Beehive[i]).Build();
                    break;
                case BeeEnum.WorkerBee:
                    ((WorkerBee)BeehiveController.Beehive[i]).CreateHoney();
                    break;
                case BeeEnum.QueenBee:
                    ((QueenBee)BeehiveController.Beehive[i]).CreateNewBee();
                    break;
            }
        }
    }

    public void EatCycle()
    {
        Bee? queenBee = BeehiveController.Beehive.FirstOrDefault(b => b.BeeType == BeeEnum.QueenBee);
        if (queenBee != null)
        {
            queenBee.Eat();
        }
        for (int i = BeehiveController.Beehive.Count - 1; i >= 0; i--)
        {
            if (BeehiveController.Beehive[i].BeeType != BeeEnum.QueenBee)
            {
                BeehiveController.Beehive[i].Eat();
            }
        }
    }
}