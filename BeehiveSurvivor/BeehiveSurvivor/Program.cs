using BeehiveSurvivor.Controllers;
using BeehiveSurvivor.Services;

namespace BeehiveSurvivor 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SimulationController simulationController = new SimulationController(new CycleService(), new CasualtiesService());
            simulationController.InitializeSimulation();
        }
    }
}