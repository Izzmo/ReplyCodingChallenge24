public class Solver1
{
    public Cell[,] Cells { get; set; }

    public List<Cell> FindShortestPath(Model model)
    {
        int width = model.GridWidth;
        int height = model.GridHeight;
        List<GoldenPoint> goldenPoints = model.GoldenPoints;

        Cells = new Cell[width, height];

        // Initialize the cells
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Cells[i, j] = new Cell { X = i, Y = j };
            }
        }

        List<Cell> shortestPath = null;

        foreach (var start in goldenPoints)
        {
            var path = new List<Cell> { };
            var remainingPoints = new List<Cell>(goldenPoints);
            remainingPoints.Remove(start);

            FindShortestPath(start, remainingPoints, path);
        }

        return shortestPath;
    }

    private static void FindShortestPath(Cell current, List<Cell> remainingPoints, List<Cell> path)
    {
        foreach (var next in remainingPoints)
        {
            var (X, Y) = GetVector(current, next);
            //horizontal cells
            var endingx = 0;
            for (int x = 1; x <= X; x++)
            {
                var next2 = new Cell { X = current.X + x, Y = current.Y };
                bool found = false;
                path.ForEach(p =>
                {
                    if (p.X == next2.X && p.Y == next2.Y)
                    {
                        found = true;
                    }
                });

                if (!found)
                {
                    path.Add(next2);
                }

                endingx = next2.X;
            }
            //vertical cells 
            for (int y = 1; y < Math.Abs(Y); y++)
            {
                var sign = Y > 0 ? 1 : -1;
                var next2 = new Cell { X = endingx, Y = current.Y + (y*sign) };
                bool found = false;
                path.ForEach(p =>
                {
                    if (p.X == next2.X && p.Y == next2.Y)
                    {
                        found = true;
                    }
                });

                if (!found)
                {
                    path.Add(next2);
                }
            }

            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(path));
        }
    }

    private static (int X, int Y) GetVector(Cell a, Cell b)
    {
        // generate an algorithm to determine the difference in the X and Y attributes of Cell a and Cell b
        return (b.X - a.X, b.Y - a.Y);
    }

    //public class Tile
    //{
    //    public bool ConnectsTop { get; set; }
    //    public bool ConnectsRight { get; set; }
    //    public bool ConnectsBottom { get; set; }
    //    public bool ConnectsLeft { get; set; }
    //    public int X { get; set; }
    //    public int Y { get; set; }
    //    // Add other properties as needed
    //}

    public List<Tile> PlaceTiles(List<Cell> cells, List<Tile> tiles)
    {
        // Initialize the list of placed tiles
        List<Tile> placedTiles = new List<Tile>();

        // Iterate over the cells
        foreach (var cell in cells)
        {
            // Find a tile that can connect to the current cell's neighbors
            Tile tile = tiles.Find(t => CanConnect(cells, t, cell.X, cell.Y));

            // If a suitable tile was found
            //if (tile != null)
            {
                // Set the tile's position
                tile.X = cell.X;
                tile.Y = cell.Y;

                // Add the tile to the list of placed tiles
                placedTiles.Add(tile);

                // Remove the tile from the list
                tiles.Remove(tile);
            }
        }

        // Return the list of placed tiles
        return placedTiles;
    }

    public bool CanConnect(List<Cell> cells, Tile tile, int x, int y)
    {
        // Check if the tile can connect to the cell's neighbors
        if (cells.Exists(c => c.X == x - 1 && c.Y == y && !tile.ConnectsTop)) return false;
        if (cells.Exists(c => c.X == x + 1 && c.Y == y && !tile.ConnectsBottom)) return false;
        if (cells.Exists(c => c.X == x && c.Y == y - 1 && !tile.ConnectsLeft)) return false;
        if (cells.Exists(c => c.X == x && c.Y == y + 1 && !tile.ConnectsRight)) return false;

        return true;
    }
}