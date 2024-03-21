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
        double shortestDistance = double.MaxValue;

        foreach (var start in goldenPoints)
        {
            var path = new List<Cell> { };
            var remainingPoints = new List<Cell>(goldenPoints);
            remainingPoints.Remove(start);

            FindShortestPath(start, remainingPoints, path, 0, shortestPath, shortestDistance);
        }

        return shortestPath;
    }

    private void FindShortestPath(Cell current, List<Cell> remainingPoints, List<Cell> path, double currentDistance, List<Cell> shortestPath, double shortestDistance)
    {
        foreach (var next in remainingPoints)
        {
            var vector = GetVector(current, next);
            //horizontal cells
            var endingx = 0;
            for (int x = 1; x <= vector.X; x++)
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
            for (int y = 1; y < Math.Abs(vector.Y); y++)
            {
                var sign = vector.Y > 0 ? 1 : -1;
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

    private (int X, int Y) GetVector(Cell a, Cell b)
    {
        // generate an algorithm to determine the difference in the X and Y attributes of Cell a and Cell b
        return (b.X - a.X, b.Y - a.Y);
    }


}