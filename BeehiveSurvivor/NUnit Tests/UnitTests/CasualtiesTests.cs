using BeehiveSurvivor.Services;
using BeehiveSurvivor.Controllers;

namespace NUnit_Tests.UnitTests;

public class CasualtiesTests
{
    private  CasualtiesService _casualtiesService = new CasualtiesService();
    private  CycleService _cycleService = new CycleService();
    
    [SetUp]
    public void Setup()
    {
        _cycleService = new CycleService();
        _casualtiesService = new CasualtiesService();
        BeehiveController.InitiateBeehive();
        BeehiveController.StoredHoney = 0;
        BeehiveController.StoredPollen = 0;
        BeehiveController.StoredWax = 0;
    }

    [Test]
    public void CleanupDeadBees()
    {
        _cycleService.EatCycle();
        _casualtiesService.CalculateCasualties();
        Assert.That(BeehiveController.Beehive.Count == 0);
    }

    [Test]
    public void LeavingSurvivors()
    {
        int totalPop = BeehiveController.Beehive.Count;
        BeehiveController.StoredHoney = totalPop / 2;
        _cycleService.EatCycle();
        _casualtiesService.CalculateCasualties();
        Assert.That(BeehiveController.Beehive.Count == totalPop/2);
    }

    [Test]
    public void QueenDead()
    {
        _cycleService.EatCycle();
        _casualtiesService.CalculateCasualties();
        Assert.True(_casualtiesService.IsQueenDead());
    }

    [Test]
    public void QueenAlive()
    {
        BeehiveController.StoredHoney = 1;
        _cycleService.EatCycle();
        _casualtiesService.CalculateCasualties();
        Assert.False(_casualtiesService.IsQueenDead());
    }
    
    
}