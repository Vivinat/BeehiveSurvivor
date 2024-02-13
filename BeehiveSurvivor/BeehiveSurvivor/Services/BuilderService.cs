using BeehiveSurvivor.Controllers;
using BeehiveSurvivor.Interfaces;

namespace BeehiveSurvivor.Services;

public class BuilderService : IBuilder
{
    public void CreateNewImprovement()
    {
        if (BeehiveController.StoredWax >= 10)
        {
            BeehiveController.BeehiveImprovements++;
            BeehiveController.StoredWax -= 10;
        }
    }
}