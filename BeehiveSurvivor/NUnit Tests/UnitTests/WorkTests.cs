using BeehiveSurvivor.Bees;
using BeehiveSurvivor.Controllers;
using BeehiveSurvivor.Factory;
using BeehiveSurvivor.Services;

namespace NUnit_Tests.UnitTests;

[TestFixture]
public class WorkTests
{
    private  CycleService _cycleService = new CycleService();
    
    [SetUp]
    public void Setup()
    {
        BeehiveController.Beehive.Clear();
        _cycleService = new CycleService();
        BeehiveController.StoredHoney = 0;
        BeehiveController.StoredPollen = 0;
        BeehiveController.StoredWax = 0;
        BeehiveController.BeehiveImprovements = 0;
    }

    [Test]
    public void TestAllForagers()
    {
        BeehiveController.Beehive.Add(new ForagerBee("test",1,BeeEnum.ForagerBee, new EatService(), new ForagerService(), new RecorderService()));
        BeehiveController.Beehive.Add(new ForagerBee("test1",1,BeeEnum.ForagerBee, new EatService(), new ForagerService(), new RecorderService()));
        BeehiveController.Beehive.Add(new ForagerBee("test2",1,BeeEnum.ForagerBee, new EatService(), new ForagerService(), new RecorderService()));
        _cycleService.WorkCycle();
        Assert.That(BeehiveController.StoredHoney >= 0 || BeehiveController.StoredWax >= 0);
    }

    [Test]
    public void LevelUpTest()
    {
        BeehiveController.Beehive.Add(new ForagerBee("test",1,BeeEnum.ForagerBee, new EatService(), new ForagerService(), new RecorderService()));
        BeehiveController.Beehive.Add(new BuilderBee("test1",1,BeeEnum.BuilderBee, new EatService(), new BuilderService(), new RecorderService()));
        BeehiveController.Beehive.Add(new WorkerBee("test2",1,BeeEnum.WorkerBee, new EatService(), new HoneyService(), new RecorderService()));
        _cycleService.WorkCycle();
        Assert.True(BeehiveController.Beehive.All(b => b.ReturnLevel() == 2));
    }

    [Test]
    public void BuilderTest()
    {
        BuilderBee builderBee = new BuilderBee("builderTest",1,BeeEnum.BuilderBee, new EatService(),new BuilderService(), new RecorderService());
        BeehiveController.StoredWax = 10;
        builderBee.Build();
        Assert.That(BeehiveController.BeehiveImprovements == 1 && BeehiveController.StoredWax == 0);
    }

    [Test]
    public void TestAllBuilders()
    {
        BeehiveController.StoredWax = 20;
        BeehiveController.Beehive.Add(new BuilderBee("test1",1,BeeEnum.BuilderBee, new EatService(), new BuilderService(), new RecorderService()));
        BeehiveController.Beehive.Add(new BuilderBee("test1",1,BeeEnum.BuilderBee, new EatService(), new BuilderService(), new RecorderService()));
        BeehiveController.Beehive.Add(new BuilderBee("test1",1,BeeEnum.BuilderBee, new EatService(), new BuilderService(), new RecorderService()));
        _cycleService.WorkCycle();
        Assert.That(BeehiveController.BeehiveImprovements == 2 && BeehiveController.StoredWax == 0);
    }

    [Test]
    public void TestForagerDeathBySting()
    {
        //Must change setting in Constants in order to force death in work 
        BeehiveController.Beehive.Add(new ForagerBee("test1",1,BeeEnum.ForagerBee, new EatService(), new ForagerService(), new RecorderService()));
        _cycleService.WorkCycle();
        Assert.True(BeehiveController.Beehive.All(b => b.IsDead));
    }
    
    [Test]
    public void DeadForagerBringsNoResources()
    {
        //Must change setting in Constants in order to force death in work
        BeehiveController.Beehive.Add(new ForagerBee("test",1,BeeEnum.ForagerBee, new EatService(), new ForagerService(), new RecorderService()));
        _cycleService.WorkCycle();
        Assert.That(BeehiveController.StoredPollen == 0 && BeehiveController.StoredWax == 0);
    }

    [Test]
    public void TestHoneyMaking()
    {
        BeehiveController.StoredPollen = 2;
        WorkerBee workerBee = new WorkerBee("test",1, BeeEnum.WorkerBee, new EatService(), new HoneyService(), new RecorderService());
        workerBee.CreateHoney();
        Assert.That(BeehiveController.StoredPollen < 2 && BeehiveController.StoredHoney == 1);
    }

    [Test]
    public void NoPollenForHoney()
    {
        WorkerBee workerBee = new WorkerBee("test",1, BeeEnum.WorkerBee, new EatService(), new HoneyService(), new RecorderService());
        workerBee.CreateHoney();
        Assert.That(BeehiveController.StoredPollen == 0 && BeehiveController.StoredHoney == 0);    
    }

    [Test]
    public void IsQueenLaying()
    {
        QueenBee queenBee = new QueenBee("test",1,BeeEnum.QueenBee, new EatService(), new BreederService(new BeeFactory()));
        queenBee.CreateNewBee();
        Assert.True(BeehiveController.Beehive.Count > 1);
    }
    
}