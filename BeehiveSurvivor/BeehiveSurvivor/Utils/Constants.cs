namespace BeehiveSurvivor.Utils;

public static class Constants
{
    public const int DifficultRating = 2;   //Higher values mean low difficult, lower values mean higher difficult
    public const int PopulationCap = 100;   //Ends the simulation when colony reaches the population cap
    public const int BirthBonus = 5;        //Gives a guarantee number of newborn bees at every laying the queen does
    public const int DisasterDamage = 2;    //Gives a guarantee value of damage from disasters
    public const int ForagerAttackChance = 0; //0-4, rate at which forager bee will have to use its sting and die
}