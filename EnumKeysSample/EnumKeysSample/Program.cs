using EnumKeysSample;

using Microsoft.EntityFrameworkCore;

using (var db = new WineContext())
{
    await db.Database.MigrateAsync();
    if (!db.Wines.Any())
    {
        db.Wines.Add(new Wine
        {
            Name = "Saperavi",
            Type = WineType.Red,
        });
        db.Wines.Add(new Wine
        {
            Name = "Cabernet",
            Type = WineType.Red,
        });
        db.Wines.Add(new Wine
        {
            Name = "Chardonnay",
            Type = WineType.White,
        });
    }

    await db.SaveChangesAsync();
}

using (var db = new WineContext())
{
    var types = await db.WineTypes
        .AsNoTracking()
        .ToListAsync();

    foreach (var type in types)
    {
        Console.WriteLine($"{type.Name} wines:");

        var wines = await db.Wines
            .AsNoTracking()
            .Include(w => w.TypeDetails)
            .Where(w => w.Type == type.Type)
            .ToListAsync();

        foreach (var wine in wines)
            Console.WriteLine($"{wine.Name} is a {wine.TypeDetails.Name} wine");
    }
}