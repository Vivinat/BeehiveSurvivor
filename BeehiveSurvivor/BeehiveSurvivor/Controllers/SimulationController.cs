using BeehiveSurvivor.Services;
using BeehiveSurvivor.Utils;

namespace BeehiveSurvivor.Controllers;

public class SimulationController
{
    private bool _endProgram;
    private CycleService _cycleService;
    private CasualtiesService _casualtiesService;
    private bool _isQueenDead;

    public SimulationController(CycleService cycleService, CasualtiesService casualtiesService)
    {
        _cycleService = cycleService;
        _casualtiesService = casualtiesService;
    }

    public void InitializeSimulation()
    {
        Console.WriteLine("Further difficult settings can be changed in the Constants class in the utils folder");
        Console.WriteLine("INITIALIZING BEEHIVE");
        BeehiveController.InitiateBeehive();
        _cycleService = new CycleService();
        _casualtiesService = new CasualtiesService();
        _isQueenDead = false;
        SingleSimulationCycle();
    }

    private void SingleSimulationCycle()
    {
        while (_endProgram != true)
        {
            while (_isQueenDead != true)
            {
                Console.WriteLine("WORK PHASE");
                _cycleService.WorkCycle();
                _cycleService.WorkCycle();
                _casualtiesService.CalculateCasualties();
                Console.WriteLine(BeehiveController.PrintBeehiveStatus());
                Console.WriteLine("EATING PHASE");
                _cycleService.EatCycle();
                _casualtiesService.CalculateCasualties();
                Console.WriteLine(BeehiveController.PrintBeehiveStatus());

                _isQueenDead = _casualtiesService.IsQueenDead();
                if (_isQueenDead)
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
            EndSimulation();
        }
    }

    private void EndSimulation()
    {
        char inputKey = 'Y';
        Console.WriteLine(BeehiveController.EndStatus());
        Console.WriteLine(
            "The simulation has ended. Press any key to end the program or the Y key to rerun the simulation");
        
        try
        {
            inputKey = char.Parse(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
        
        if (inputKey != 'Y')
        {
            _endProgram = true;
            return;
        }
        InitializeSimulation();
    }
}
