namespace EFoodAPI;


public record Query(string Year, string Week, List<string> SeekLabels, List<string> IgnoreLabels, List<string> SeekIngredients, List<string> IgnoreIngredients, Calorie Calorie, Carb Carb, Protein Protein, Fat Fat, Price Price, bool Favorites, bool LastMinute)
{
    public Query(int year, int week) : this(
        Year: year.ToString(),
        Week: week.ToString(),
        SeekLabels: new List<string>(),
        IgnoreLabels: new List<string>(),
        SeekIngredients: new List<string>(),
        IgnoreIngredients: new List<string>(),
        Calorie: new Calorie(),
        Carb: new Carb(),
        Protein: new Protein(),
        Fat: new Fat(),
        Price: new Price(),
        Favorites: false,
        LastMinute: false)
    { }
}

public record Calorie(int min = 0, int max = 9000);

public record Carb(int min = 0, int max = 9000);

public record Protein(int min = 0, int max = 9000);

public record Fat(int min = 0, int max = 9000);

public record Price(int min = 0, int max = 9000);
