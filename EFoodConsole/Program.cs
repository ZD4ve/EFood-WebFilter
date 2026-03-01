using static EFoodAPI.EFoodAPI;
var foodsTask = GetFoods();
var foods1Task = GetFoods(1);
var foods = await foodsTask;
foods.AddRange(await foods1Task);
Console.WriteLine("\tProt\tCal\t(Prot/100Cal)");

foods
    .GroupBy(x => x.Date)
    .Select(d => d.Key.ToString("dddd") + "\n" + string.Join("\n", d
        .Where(x => x.Orderable)
        .Where(x => x.Protein >= 40)
        .OrderByDescending(x => x.Protein)
        .Select(x => $"\t{x.Protein}\t{x.Calories}\t({x.ProteinPer100Calorie:0.00})\t{x.Name}")
        //.Take(10)
        ))
    .Select(d => d)
    .ToList()
    .ForEach(Console.WriteLine);
Console.ReadKey();
