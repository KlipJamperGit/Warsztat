namespace WarsztatProjekt;

public static class Sortuwanie
{
    public static T FindElement<T>(List<T> collection, Predicate<T> match)
    {
        foreach (var item in collection)
        {
            if (match(item))
            {
                return item;
            }
        }
        Console.WriteLine("Pusto.");
        return default;
    }
}