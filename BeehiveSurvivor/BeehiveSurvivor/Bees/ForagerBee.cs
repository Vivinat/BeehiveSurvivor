using BeehiveSurvivor.Services;

namespace BeehiveSurvivor.Bees;

public class ForagerBee : Bee
{
    private readonly ForagerService _foragerService;
    public ForagerBee(string name, int level,BeeEnum beeType, EatService eatService, ForagerService foragerService) : base(name, level, beeType, eatService)
    {
        _foragerService = foragerService;
    }

    public void Forage()
    {
        bool wasAttacked = _foragerService.Forage(Level);
        if (wasAttacked)
        {
            UseSting();
        }
        else
        {
            EarnLevel();    
        }
    }

    private void UseSting()
    {
        Die("used her sting and died!");
    }
}