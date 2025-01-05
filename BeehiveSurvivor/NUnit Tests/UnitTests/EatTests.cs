using BeehiveSurvivor.Bees;
using BeehiveSurvivor.Controllers;
using BeehiveSurvivor.Services;

namespace NUnit_Tests.UnitTests;

[TestFixture]
public class EatTests
{
    private  CycleService _cycleService = new CycleService();
    private  CasualtiesService _casualtiesService = new CasualtiesService();
    
    [SetUp]
    public void Setup()
    {
        BeehiveController.Beehive.Clear();
        _cycleService = new CycleService();
        _casualtiesService = new CasualtiesService();
        BeehiveController.InitiateBeehive();
        BeehiveController.StoredHoney = 0;
        BeehiveController.StoredPollen = 0;
        BeehiveController.StoredWax = 0;
    }

    [Test]
    public void DoesAllBeesEat()
    {
        BeehiveController.StoredHoney = 10;
        int totalHoney = 10;
        _cycleService.EatCycle();
        Assert.That(BeehiveController.StoredHoney, Is.EqualTo(totalHoney - BeehiveController.Beehive.Count));
    }

    [Test]
    public void IsQueenEatingFirst()
    {
        BeehiveController.StoredHoney = 1;
        _cycleService.EatCycle();
        _casualtiesService.CalculateCasualties();
        Assert.That(BeehiveController.Beehive.Count == 1 && BeehiveController.Beehive[0].BeeType == BeeEnum.QueenBee);
    }

    [Test]
    public void AllDeadByStarvation()
    {
        _cycleService.EatCycle();
        Assert.IsTrue(BeehiveController.Beehive.All(b => b.IsDead));
    }

    [Test]
    public void OneDeathByStarvation()
    {
        BeehiveController.StoredHoney = BeehiveController.Beehive.Count - 1;
        _cycleService.EatCycle();
        Assert.IsTrue(BeehiveController.Beehive.Count(b => b.IsDead) == 1 &&
                      BeehiveController.Beehive.Single(b => b.IsDead).IsDead);
    }

    [Test]
    public void IsHoneyRestingToZero()
    {
        BeehiveController.StoredHoney = 1;
        _cycleService.EatCycle();
        _cycleService.EatCycle();
        _cycleService.EatCycle();
        Assert.That(BeehiveController.StoredHoney, Is.EqualTo(0));
    }

    [Test]
    public void VerifyPermanencyInHiveAfterStarvation()
    {
        int totalBees = BeehiveController.Beehive.Count;
        _cycleService.EatCycle();
        Assert.That(totalBees, Is.EqualTo(BeehiveController.Beehive.Count));
    }
    
    [Test]
    public void HoneyWhenNoBeesInHive()
    {
        BeehiveController.StoredHoney = 10;
        BeehiveController.Beehive.Clear();
        _cycleService.EatCycle();
        Assert.That(BeehiveController.StoredHoney == 10);
    }
}