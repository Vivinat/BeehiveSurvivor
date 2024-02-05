using BeehiveSurvivor.Interfaces;
using BeehiveSurvivor.Controllers;
namespace BeehiveSurvivor.Services;

public class EatService : IEat
{
    public bool Eat()
    {
        BeehiveController.StoredHoney--;
        if (BeehiveController.StoredHoney < 0)
        {
            BeehiveController.StoredHoney = 0;
            return true;
        }
        return false;
    }
}