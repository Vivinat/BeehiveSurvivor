using BeehiveSurvivor.Services;

namespace BeehiveSurvivor.Bees;

public class BuilderBee : Bee
{
    private readonly BuilderService _builderService;
    
    public BuilderBee(string name,int level, BeeEnum beeType, EatService eatService, BuilderService builderService ) : base(name, level, beeType, eatService)
    {
        _builderService = builderService;
    }

    public void Build()
    {
        _builderService.CreateNewImprovement();
        EarnLevel();
    }
}