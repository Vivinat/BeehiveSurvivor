using System.Text;
using BeehiveSurvivor.Bees;

namespace BeehiveSurvivor.Controllers;

public class StatisticsController
{
    private static StringBuilder _sb = new StringBuilder();
    
    public static string DisplayAllStatistics()
    {
        _sb.AppendLine("STATISTICS");
        _sb.AppendLine("BEES WITH THE MOST LEVEL");
        SeniorBeesQuery();
        MostBeesQuery();
        return _sb.ToString();
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
                _sb.AppendLine(
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
            _sb.AppendLine(
                $"The hive is mostly populated by bees of the type {mostCommonBeeType.BeeType}, with {mostCommonBeeType.Count} individuals");
        }
    }
}