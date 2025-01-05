using System.Text;
using BeehiveSurvivor.Bees;
using BeehiveSurvivor.Factory;
using BeehiveSurvivor.Services;
using BeehiveSurvivor.Utils;

namespace BeehiveSurvivor.Controllers;

public static class BeehiveController
{
    public static List<Bee> Beehive = new List<Bee>();
    public static int BeehiveImprovements;
    public static int StoredHoney { get; set; }
    public static int StoredPollen { get; set; }
    public static int StoredWax { get; set; }
    
    private static int SurvivedMonths { get; set; }
    private static int SurvivedYears { get; set; }
    
    public static void InitiateBeehive()
    {
        Beehive.Clear();
        StoredHoney = 0;
        StoredPollen = 0;
        StoredWax = 0;
        SurvivedMonths = 0;
        SurvivedYears = 0;
        QueenBee queenBee = new QueenBee(NameController.GenerateName(), 1, BeeEnum.QueenBee, new EatService(), new BreederService(new BeeFactory()));
        Beehive.Add(queenBee);
        queenBee.CreateNewBee();
    }
    
    public static string PrintBeehiveStatus()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"There are {Beehive.Count} bees in the colony");
        sb.AppendLine($"Pollen Stored {StoredPollen}");
        sb.AppendLine($"Honey Stored {StoredHoney}");
        sb.AppendLine($"Wax Stored {StoredWax}");
        sb.AppendLine($"There are {BeehiveImprovements} improvements");
        return sb.ToString();
    }

    public static void PassMonths()
    {
        SurvivedMonths++;
        if (SurvivedMonths > 12)
        {
            SurvivedMonths = 1;
            SurvivedYears++;
        }
    }

    public static string EndStatus()
    {
        return $"The Beehive survived for {SurvivedMonths} months and {SurvivedYears} years";
    }

    public static string AchieveMaxPopulation()
    {
        return "The Beehive's population has achieved the desired limit. Ending simulation";
    }
    
}