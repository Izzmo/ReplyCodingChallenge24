public class Model
{
    // --- input fields ---

    public int GridWidth { get; set; }
    public int GridHeight { get; set; }
    public int GoldenPointsAvailable { get; set; }
    public int SilverPointsAvailable { get; set; }
    public int TypesOfTilesAvailable { get; set; }

    public int[] Field { get; set; }

    public bool[] Taken { get; set; }

    public void InitTaken()
    {
        Taken = new bool[GridWidth * GridHeight];
    }

    // --- result fields ---

    public long Score { get; set; }
    public string Name { get; set; }

    public List<GoldenPoint> GoldenPoints { get; set; } = new();
    public List<SilverPoint> SilverPoints { get; set; } = new();
    public List<Tile> Tiles { get; set; } = new();
    public List<Tile> FlattenedTiles { get; set; } = new();

    public double VirtualFieldScore(int index)
    {
        var offset = 0;
        var (x, y) = FromIndex(index);

        //offset += R.Next(100);

        //var neighbors = Neighbors(x, y, Field);
        //// exactly 2 neighbors taken
        //if (neighbors.Count(n => Taken[n.Index]) == 2)
        //{
        //    offset += 50;
        //}


        return offset + Field[index];
    }

    public int ToIndex(int x, int y)
    {
        return x + y * GridWidth;
    }

    public bool IsPortal(int x, int y)
    {
        return Field[ToIndex(x, y)] == Portal;
    }

    public int WrapAroundIndex(int x, int y)
    {
        if (x < 0) x = GridWidth - 1;
        if (y < 0) y = GridHeight - 1;
        if (x == GridWidth) x = 0;
        if (y == GridHeight) y = 0;

        return x + y * GridWidth;
    }

    public List<Neighbor> Neighbors(int x, int y, int[] fields)
    {
        return new List<Neighbor>
        {
            NeighborOf(x, y, x - 1, y, fields), // left
            NeighborOf(x, y, x, y - 1, fields), // top
            NeighborOf(x, y, x + 1, y, fields), // right
            NeighborOf(x, y, x, y + 1, fields), // bottom
        };
    }


    private Neighbor NeighborOf(int x0, int y0, int x, int y, int[] fields)
    {
        var index = WrapAroundIndex(x, y);

        return new Neighbor { Index = index, Value = fields[index], Owner = (x0, y0) };
    }

    public const int Portal = int.MinValue;

    public (int x, int y) FromIndex(int idx)
    {
        return (idx % GridWidth, idx / GridWidth);
    }
}

public class Neighbor
{
    public int Value;
    public int Index;

    public (int x0, int y0) Owner { get; set; }
}