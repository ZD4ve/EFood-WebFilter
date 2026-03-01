using static System.Net.WebRequestMethods;

namespace EFoodAPI;


public class Food
{
    public string Name { get; set; }

    public int Id { get; set; }
    public int Price { get; set; }
    public DateOnly Date { get; set; }

    public double Calories { get; set; }
    public double Carbohydrates { get; set; }
    public double Protein { get; set; }
    public double Fat { get; set; }

    public double Calories100g { get; set; }
    public double Carbohydrates100g { get; set; }
    public double Protein100g { get; set; }
    public double Fat100g { get; set; }

    public bool Orderable { get; set; }

    public double ProteinPer100Calorie => (Protein / Calories) * 100;
    public override string? ToString() => Name;
    public string ImageUrl => $"https://ea.e-food.hu/api/v1/i?menu_item_id={Id}";

}

public class MenuResponse
{
    public bool Error { get; set; }
    public Dictionary<string, MenuGroup> Data { get; set; }

    public List<Food> GetFoods() =>
        Data
        .Values
        .SelectMany(g => g.Categories)
        .SelectMany(c => c.Items)
        .Select(item => new Food
        {
            Name = item.Food.Name.Replace("*", ""),
            Id = item.Id,
            Price = item.Price,
            Date = DateOnly.Parse(item.Date),
            Calories = item.EnergyPortionFoodOne,
            Fat = item.FatPortionFoodOne,
            Carbohydrates = item.CarbPortionFoodOne,
            Protein = item.ProteinPortionFoodOne,
            Calories100g = item.EnergyHundredFoodOne,
            Fat100g = item.FatHundredFoodOne,
            Carbohydrates100g = item.CarbHundredFoodOne,
            Protein100g = item.ProteinHundredFoodOne,
            Orderable = !item.Disabled
        })
        .ToList();
}

public class MenuGroup
{
    public List<MenuCategory> Categories { get; set; }
}

public class MenuCategory
{
    public List<MenuItem> Items { get; set; }
}

public class MenuItem
{
    public FoodLabel Food { get; set; }
    public int Id { get; set; }
    public int Price { get; set; }
    public string Date { get; set; }
    public double EnergyPortionFoodOne { get; set; }
    public double FatPortionFoodOne { get; set; }
    public double SaturatedFatPortionFoodOne { get; set; }
    public double CarbPortionFoodOne { get; set; }
    public double SugarPortionFoodOne { get; set; }
    public double ProteinPortionFoodOne { get; set; }
    public double SaltPortionFoodOne { get; set; }
    public double EnergyHundredFoodOne { get; set; }
    public double FatHundredFoodOne { get; set; }
    public double SaturatedFatHundredFoodOne { get; set; }
    public double CarbHundredFoodOne { get; set; }
    public double SugarHundredFoodOne { get; set; }
    public double ProteinHundredFoodOne { get; set; }
    public double SaltHundredFoodOne { get; set; }
    public bool Disabled { get; set; }
}

public class FoodLabel
{
    public string Name { get; set; }
}
