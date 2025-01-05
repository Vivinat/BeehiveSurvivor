using BeehiveSurvivor.Controllers;
using BeehiveSurvivor.Interfaces;
using BeehiveSurvivor.Utils;

namespace BeehiveSurvivor.Services;

public class ForagerService : IForager
{
    public bool Forage(int beeLevel, RecorderService recorderService)
    {
        Random random = new Random();
        int forageType = random.Next(0, 2);
        int attackChance = random.Next(0, 5);
        if (attackChance <= Constants.ForagerAttackChance)
        {
            return true;
        }

        switch (forageType)
        {
            case 0:
                BeehiveController.StoredPollen += beeLevel * Constants.DifficultRating;
                recorderService.NumberOfImprovements += beeLevel * Constants.DifficultRating;
                break;
            case 1:
                BeehiveController.StoredWax += beeLevel * Constants.DifficultRating;
                recorderService.NumberOfImprovements += beeLevel * Constants.DifficultRating;
                break;
        }

        return false;

    }
}