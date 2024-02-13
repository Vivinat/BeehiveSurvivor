
using BeehiveSurvivor.Controllers;
using BeehiveSurvivor.Interfaces;

namespace BeehiveSurvivor.Services;

public class HoneyService : IHoney
{
    public void CreateHoney(int beeLevel)
    {
        if (BeehiveController.StoredPollen > 0)
        {
            Random random = new Random();
            int pollenUsed = random.Next(1, 3);
            BeehiveController.StoredPollen -= pollenUsed;
            if (BeehiveController.StoredPollen < 0)
            {
                BeehiveController.StoredPollen = 0;
            }
            BeehiveController.StoredHoney += beeLevel;
        }
    }
}