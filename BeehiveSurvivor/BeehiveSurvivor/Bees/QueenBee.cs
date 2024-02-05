
using BeehiveSurvivor.Services;

namespace BeehiveSurvivor.Bees;

public class QueenBee : Bee
{
    private readonly BreederService _breederService;
    
    public QueenBee(string name,int level,BeeEnum beeType, BreederService breederService) : base(name, level, beeType)
    {
        _breederService = breederService;
    }

    public void CreateNewBee()
    {
        _breederService.CreateNewBee();
    }
}