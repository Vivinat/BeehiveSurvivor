namespace BeehiveSurvivor.Controllers;

public enum DisasterType : int
{
    HoneyPlundered = 0,
    PollenTaken = 1,
    WaxDestroyed = 2,
    NoDisasters = 3
}

public static class DisasterController
{
    public static string Disasters()
    {
        Random random = new Random();
        DisasterType disasterType = (DisasterType)random.Next(0, 3);
        int disasterDamage = (random.Next(1, 10) - BeehiveController.BeehiveImprovements) + Utils.Constants.DisasterDamage;

        if (disasterDamage <= 0)
        {
            return "The improvements thwarted the disaster";
        }

        string disasterDescription = "";

        int storedResource = 0; // Variável local para armazenar o valor da propriedade

        switch (disasterType)
        {
            case DisasterType.HoneyPlundered:
                storedResource = BeehiveController.StoredHoney; 
                disasterDescription = PlunderResources("honey", ref storedResource, disasterDamage);
                BeehiveController.StoredHoney = storedResource; 
                break;
            case DisasterType.PollenTaken:
                storedResource = BeehiveController.StoredPollen;
                disasterDescription = PlunderResources("pollen", ref storedResource, disasterDamage);
                BeehiveController.StoredPollen = storedResource;
                break;
            case DisasterType.WaxDestroyed:
                storedResource = BeehiveController.StoredWax;
                disasterDescription = PlunderResources("wax", ref storedResource, disasterDamage);
                BeehiveController.StoredWax = storedResource;
                break;
            case DisasterType.NoDisasters:
                disasterDescription = "No disasters happened this month";
                break;
        }

        return disasterDescription;
    }

    private static string PlunderResources(string resourceName, ref int storedResource, int disasterDamage)
    {
        storedResource -= disasterDamage;
        if (storedResource < 0)
        {
            storedResource = 0;
        }
        return $"Some {resourceName} was affected by a disaster";
    }

    
    
}