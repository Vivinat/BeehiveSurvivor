using BeehiveSurvivor.Controllers;
using BeehiveSurvivor.Services;

namespace BeehiveSurvivor.Bees;

public class ForagerBee : Bee
{
    private readonly ForagerService _foragerService;
    private readonly RecorderService _recorderService;
    public ForagerBee(string name, int level,BeeEnum beeType, EatService eatService, ForagerService foragerService, RecorderService recorderService) : base(name, level, beeType, eatService)
    {
        _foragerService = foragerService;
        _recorderService = recorderService;
        _recorderService.Name = name;
        _recorderService.BeeType = beeType;
        _recorderService.Level = 1;
    }

    public void Forage()
    {
        bool wasAttacked = _foragerService.Forage(Level, _recorderService);
        if (wasAttacked)
        {
            UseSting();
        }
        else
        {
            EarnLevel();  
            _recorderService.Level++;
            StatisticsController.RetrieveRecord(Name,Level,_recorderService.NumberOfImprovements,BeeEnum.ForagerBee);
        }
    }

    private void UseSting()
    {
        Die("used her sting and died!");
    }
}