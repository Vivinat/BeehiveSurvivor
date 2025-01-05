using BeehiveSurvivor.Controllers;
using BeehiveSurvivor.Services;

namespace BeehiveSurvivor.Bees;

public class BuilderBee : Bee
{
    private readonly BuilderService _builderService;
    private readonly RecorderService _recorderService;
    
    public BuilderBee(string name,int level, BeeEnum beeType, EatService eatService, BuilderService builderService, RecorderService recorderService) : base(name, level, beeType, eatService)
    {
        _builderService = builderService;
        _recorderService = recorderService;
        _recorderService.Name = name;
        _recorderService.BeeType = beeType;
        _recorderService.Level = 1;
    }

    public void Build()
    {
        _builderService.CreateNewImprovement(_recorderService);
        EarnLevel();
        _recorderService.Level++;
        StatisticsController.RetrieveRecord(Name, Level, _recorderService.NumberOfImprovements, BeeEnum.BuilderBee);
    }
}