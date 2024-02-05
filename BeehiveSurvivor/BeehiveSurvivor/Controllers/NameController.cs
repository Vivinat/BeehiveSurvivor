namespace BeehiveSurvivor.Controllers;

public static class NameController
{
    public static string GenerateName()
    {
        var nameComponents = new[] { "ba", "be", "bi", "bo", "bu", "da", "de", "di", "do", "du", "fa", "fe", "fi", "fo", "fu", "ga", "ge", "gi", "go", "gu", "ha", "he", "hi", "ho", "hu", "ja", "je", "ji", "jo", "ju", "ka", "ke", "ki", "ko", "ku", "la", "le", "li", "lo", "lu", "ma", "me", "mi", "mo", "mu", "na", "ne", "ni", "no", "nu", "pa", "pe", "pi", "po", "pu", "ra", "re", "ri", "ro", "ru", "sa", "se", "si", "so", "su", "ta", "te", "ti", "to", "tu", "va", "ve", "vi", "vo", "vu", "xa", "xe", "xi", "xo", "xu", "za", "ze", "zi", "zo", "zu" };

        var random = new Random();

        var newName = "";
        for (int i = 0; i < random.Next(1, 5); i++)
        { 
            newName += nameComponents[random.Next(nameComponents.Length)];
        }

        return newName;
    }
}