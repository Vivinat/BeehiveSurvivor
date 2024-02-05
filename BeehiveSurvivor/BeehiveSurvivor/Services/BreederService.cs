using BeehiveSurvivor.Bees;
using BeehiveSurvivor.Interfaces;
using BeehiveSurvivor.Controllers;
using BeehiveSurvivor.Utils;

namespace BeehiveSurvivor.Services;

public class BreederService : IBreeder
{
    public void CreateNewBee()
    {
        Random random = new Random();
        int newbornType;
        int numberOfBirths = random.Next(1, 5) + Constants.BirthBonus;
        Console.WriteLine("Number of newborn bees: " + numberOfBirths);

        while (numberOfBirths > 0)
        {
            string newBeeName = NameController.GenerateName();
            newbornType = random.Next(0, 3);
            if (newbornType == 0)
            {
                BeehiveController.Beehive.Add(new ForagerBee(newBeeName, 1,BeeEnum.ForagerBee, new ForagerService()));
                Console.WriteLine("Forager Bee " + newBeeName + " ready for work");
                numberOfBirths--;
                continue;
            }

            if (newbornType == 1)
            {
                BeehiveController.Beehive.Add(new BuilderBee(newBeeName, 1,BeeEnum.BuilderBee, new BuilderService()));
                Console.WriteLine("Forager Bee " + newBeeName + " ready for work");
                numberOfBirths--;
                continue;
            }
            
            BeehiveController.Beehive.Add(new WorkerBee(newBeeName,1, BeeEnum.WorkerBee, new HoneyService()));
            Console.WriteLine("Worker Bee " + newBeeName + " ready for work");
            numberOfBirths--;
        }
    }
}