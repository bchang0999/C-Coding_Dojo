Console.WriteLine("Hello, World!");
List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46,"Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!

Eruption? FirstEruptionInChile = eruptions.FirstOrDefault(e => e.Location=="Chile");
Console.WriteLine(FirstEruptionInChile.ToString());

Eruption? FirstEruptionInHawaii = eruptions.FirstOrDefault(m => m.Location=="Hawaiian Is");
if  (FirstEruptionInHawaii==null){
    Console.WriteLine("No Hawaiin is Eruption found");
}else{
Console.WriteLine(FirstEruptionInHawaii.ToString());
}

Eruption? FirstEruptionAfter1900 = eruptions.First(l => l.Location =="New Zealand" && l.Year >1900);
Console.WriteLine(FirstEruptionAfter1900.ToString());

IEnumerable<Eruption> AllEruptionsOver2000Meters = eruptions.Where(c => c.ElevationInMeters > 2000);
PrintEach(AllEruptionsOver2000Meters);

IEnumerable<Eruption> AllEruptionsZ = eruptions.Where(z => z.Volcano.StartsWith("z")).ToList();
PrintEach(AllEruptionsZ);
Console.WriteLine(AllEruptionsZ .Count());

int maxLength = eruptions.Max(x => x.ElevationInMeters);
Console.WriteLine(maxLength);

IEnumerable<Eruption> Tallest = eruptions.Where(z => z.ElevationInMeters > 0);
int MaxLength = Tallest.Max(x => x.ElevationInMeters);
Eruption? chad = eruptions.FirstOrDefault(s => s.ElevationInMeters == MaxLength);
Console.WriteLine( chad.Volcano);


IEnumerable<Eruption> ABCOrder = eruptions.OrderBy(a => a.Volcano);
PrintEach(ABCOrder);

IEnumerable<Eruption> ABCYearOrder = eruptions.Where(a => a.Year < 1000).OrderBy(a => a.Volcano);
PrintEach(ABCYearOrder);
// Helper method to print each item in a List or IEnumerable.This should remain at the bottom of your class!
static void PrintEach(IEnumerable<dynamic> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (var item in items)
    {
        Console.WriteLine(item.ToString());
    }
}
