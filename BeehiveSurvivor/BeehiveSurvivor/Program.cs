using BeehiveSurvivor.Controllers;
using BeehiveSurvivor.Services;
using BeehiveSurvivor.Utils;

namespace BeehiveSurvivor 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Further difficult settings can be changed in the Constants class in the utils folder");
            BeehiveController.InitiateBeehive();
            CycleService cycleService = new CycleService();
            CasualtiesService casualtiesService = new CasualtiesService();
            bool isQueenDead = false;
            
            while (isQueenDead != true)
            {
                cycleService.WorkCycle();
                cycleService.WorkCycle();
                casualtiesService.CalculateCasualties();
                Console.WriteLine(BeehiveController.PrintBeehiveStatus());
                cycleService.EatCycle();
                casualtiesService.CalculateCasualties();
                Console.WriteLine(BeehiveController.PrintBeehiveStatus());
                
                isQueenDead = casualtiesService.IsQueenDead();
                if (isQueenDead)
                {
                    Console.WriteLine("The queen is dead. The beehive is over");
                    break;
                }

                if (BeehiveController.Beehive.Count > Constants.PopulationCap)
                {
                    Console.WriteLine(BeehiveController.AchieveMaxPopulation());
                    Console.WriteLine(StatisticsController.DisplayAllStatistics());
                    break;
                }
                
                Console.WriteLine(DisasterController.Disasters());
                Console.WriteLine(BeehiveController.PrintBeehiveStatus());
                BeehiveController.PassMonths();
            }
            Console.WriteLine(BeehiveController.EndStatus());
        }
    }
}