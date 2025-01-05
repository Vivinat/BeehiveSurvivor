using System.Text;
using BeehiveSurvivor.Bees;
using BeehiveSurvivor.Services;

namespace BeehiveSurvivor.Controllers;

public static class StatisticsController
{
    private static readonly StringBuilder Sb = new StringBuilder();
    public static int TotalBornBees { get; set; }
    public static int TotalDeadBees { get; set; }
    
    private static ForagerBee? RecordForager { get; set; }
    private static BuilderBee? RecordBuilder { get; set; }
    private static WorkerBee? RecordWorker { get; set; }
    private static int RecordBuilderNumber { get; set; }
    private static int RecordForagerNumber { get; set; }
    private static int RecordWorkerNumber { get; set; }
    
    public static string DisplayAllStatistics()
    {
        Sb.AppendLine("STATISTICS");
        Sb.AppendLine("ALIVE BEES WITH THE MOST LEVEL");
        SeniorBeesQuery();
        MostBeesQuery();
        RecordAllTimeBees();
        FinishRecord();
        return Sb.ToString();
    }

    private static void RecordAllTimeBees()
    {
        Sb.AppendLine($"A total of {TotalBornBees} bees were born and {TotalDeadBees} have died since the colony began");
    }

    private static void RecordBee(string name, int level, int numberOfImprovements, BeeEnum beeType)
    {
        switch (beeType)
        {
            case BeeEnum.BuilderBee:
                RecordBuilder = new BuilderBee(name, level, BeeEnum.BuilderBee, new EatService(), new BuilderService(), new RecorderService());
                RecordBuilderNumber = numberOfImprovements;
                break;
            case BeeEnum.ForagerBee:
                RecordForager = new ForagerBee(name, level, BeeEnum.BuilderBee, new EatService(), new ForagerService(), new RecorderService());
                RecordForagerNumber = numberOfImprovements;
                break;
            case BeeEnum.WorkerBee:
                RecordWorker = new WorkerBee(name, level, BeeEnum.BuilderBee, new EatService(), new HoneyService(), new RecorderService());
                RecordWorkerNumber = numberOfImprovements;
                break;
        }
    }

    public static void RetrieveRecord(string name, int level, int numberOfImprovements, BeeEnum beeType)
    {
        switch (beeType)
        {
            case BeeEnum.BuilderBee:
                if (RecordBuilder == null)
                {
                    RecordBee(name, level, numberOfImprovements, beeType);
                    return;
                }
                if (numberOfImprovements > RecordBuilderNumber)
                {
                    RecordBee(name, level, numberOfImprovements, beeType);
                }
                break;
            case BeeEnum.ForagerBee:
                if (RecordForager == null)
                {
                    RecordBee(name, level, numberOfImprovements, beeType);
                    return;
                }
                if (numberOfImprovements > RecordForagerNumber)
                {
                    RecordBee(name, level, numberOfImprovements, beeType);
                }
                break;
            case BeeEnum.WorkerBee:
                if (RecordWorker == null)
                {
                    RecordBee(name, level, numberOfImprovements, beeType);
                    return;
                }
                if (numberOfImprovements > RecordWorkerNumber)
                {
                    RecordBee(name, level, numberOfImprovements, beeType);
                }
                break;
        }
    }

    private static void FinishRecord()
    {
        if (RecordBuilder != null && RecordForager != null && RecordWorker != null)
        {
            Sb.AppendLine(
                $"The builder bee with the most concluded hive improvements is {RecordBuilder.Name}, {RecordBuilderNumber}");
            Sb.AppendLine(
                $"The forager bee with the most concluded expeditions is {RecordForager.Name}, {RecordForagerNumber}");
            Sb.AppendLine(
                $"The worker bee that created the most amount of honey is {RecordWorker.Name}, {RecordWorkerNumber}");    
        }
    }
    
    private static void SeniorBeesQuery()
    {
        for (int i = 1; i <= 3; i++)
        {
            var seniorForagerBee = BeehiveController.Beehive
                .Where(b => (int)b.BeeType == i) 
                .OrderByDescending(b => b.ReturnLevel()) 
                .FirstOrDefault();
            if (seniorForagerBee != null)
            {
                Sb.AppendLine(
                    $"{seniorForagerBee.Name}, {seniorForagerBee.BeeType} - LEVEL {seniorForagerBee.ReturnLevel()}");
            }
        }
    }

    private static void MostBeesQuery()
    {
        var groupedBees = BeehiveController.Beehive.GroupBy(b => b.BeeType)
            .Select(g => new { BeeType = g.Key, Count = g.Count() })
            .OrderByDescending(g => g.Count);
        
        var mostCommonBeeType = groupedBees.FirstOrDefault();

        if (mostCommonBeeType != null)
        {
            Sb.AppendLine(
                $"The hive is mostly populated by bees of the type {mostCommonBeeType.BeeType}, with {mostCommonBeeType.Count} individuals");
        }
    }
}