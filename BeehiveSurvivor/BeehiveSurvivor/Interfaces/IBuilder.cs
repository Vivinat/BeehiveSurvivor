using BeehiveSurvivor.Services;

namespace BeehiveSurvivor.Interfaces;

public interface IBuilder
{
    public void CreateNewImprovement(RecorderService recorderService);
}