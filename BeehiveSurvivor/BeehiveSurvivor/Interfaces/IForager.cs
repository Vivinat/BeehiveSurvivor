using BeehiveSurvivor.Services;

namespace BeehiveSurvivor.Interfaces;

public interface IForager
{
    public bool Forage(int beeLevel, RecorderService recorderService);
}