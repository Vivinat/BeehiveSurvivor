using BeehiveSurvivor.Services;

namespace BeehiveSurvivor.Interfaces;

public interface IHoney
{
    public void CreateHoney(int beeLevel, RecorderService recorderService);
}