using BeehiveSurvivor.Bees;

namespace BeehiveSurvivor.Services;

public class RecorderService
{
    public string Name { get; set; }
    public BeeEnum BeeType { get; set;}
    public int Level { get; set; }
    public int NumberOfImprovements { get; set; }

}