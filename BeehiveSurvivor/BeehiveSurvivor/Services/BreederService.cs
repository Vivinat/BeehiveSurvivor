using BeehiveSurvivor.Bees;
using BeehiveSurvivor.Interfaces;
using BeehiveSurvivor.Controllers;
using BeehiveSurvivor.Utils;

namespace BeehiveSurvivor.Services;

public class BreederService : IBreeder
{
    private readonly IBeeFactory _beeFactory;

    public BreederService(IBeeFactory beeFactory)
    {
        _beeFactory = beeFactory;
    }
    
    public void CreateNewBee()
    {
        Random random = new Random();
        int numberOfBirths = random.Next(1, 5) + Constants.BirthBonus;
        Console.WriteLine("Number of newborn bees: " + numberOfBirths);

        while (numberOfBirths > 0)
        {
            string newBeeName = NameController.GenerateName();
            BeeEnum beeType = (BeeEnum)random.Next(1, (int)BeeEnum.Count);
            BeehiveController.Beehive.Add(_beeFactory.CreateBee(newBeeName, beeType));
            Console.WriteLine($"{beeType} {newBeeName} ready for work");
            numberOfBirths--;
        }
    }
}