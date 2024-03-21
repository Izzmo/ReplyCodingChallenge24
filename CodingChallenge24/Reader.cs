public class Reader
{
    public static Model ReadModel(string path)
    {
        var model = new Model();

        var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
        model.Name = fileNameWithoutExtension;

        var allLines = File.ReadAllLines(path);

        var entries = allLines[0].Split(" ");
        model.GridWidth = int.Parse(entries[0]);
        model.GridHeight = int.Parse(entries[1]);
        
        model.GoldenPointsAvailable = int.Parse(entries[2]);
        model.SilverPointsAvailable = int.Parse(entries[3]);
        model.TypesOfTilesAvailable = int.Parse(entries[4]);

        var index = 1;
        for (var i = index; i <= model.GoldenPointsAvailable; i++)
        {
            var values = allLines[i].Split(" ");
            model.GoldenPoints.Add(new GoldenPoint { X = int.Parse(values[0]), Y = int.Parse(values[1]) });
            index++;
        }
        
        for (var i = index; i <= model.SilverPointsAvailable; i++)
        {
            var values = allLines[i].Split(" ");
            model.SilverPoints.Add(new SilverPoint { X = int.Parse(values[0]), Y = int.Parse(values[1]), score = int.Parse(values[2]) });
            index++;
        }

        for (var i = index; i <= model.TypesOfTilesAvailable; i++)
        {
            var values = allLines[i].Split(" ");
            model.Tiles.Add(new Tile { id = values[0], tileCost = int.Parse(values[1]), numAvailableTiles = int.Parse(values[2]) });
            index++;
        }

        return model;
    }
}

public class Cell
{
    public int X { get; set; }
    public int Y { get; set; }
}

public class GoldenPoint : Cell
{
}

public class SilverPoint : Cell
{
    public int score { get; set; }
}

public struct Tile
{
    public string id { get; set; }
    public int tileCost { get; set; }
    public int numAvailableTiles { get; set; }
}
