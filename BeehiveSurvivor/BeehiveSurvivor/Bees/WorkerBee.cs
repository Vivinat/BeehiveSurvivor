using BeehiveSurvivor.Controllers;
using BeehiveSurvivor.Services;

namespace BeehiveSurvivor.Bees;

public class WorkerBee : Bee
{
    private readonly HoneyService _honeyService;
    private readonly RecorderService _recorderService;
    public WorkerBee(string name, int level,BeeEnum beeType, EatService eatService, HoneyService honeyService, RecorderService recorderService) : base(name, level, beeType, eatService)
    {
        _honeyService = honeyService;
        _recorderService = recorderService;
        _recorderService.Name = name;
        _recorderService.BeeType = beeType;
        _recorderService.Level = 1;

    }

    public void CreateHoney()
    {
        _honeyService.CreateHoney(Level, _recorderService);
        EarnLevel();
        _recorderService.Level++;
        StatisticsController.RetrieveRecord(Name,Level,_recorderService.NumberOfImprovements, BeeEnum.WorkerBee);
    }
    
    
}