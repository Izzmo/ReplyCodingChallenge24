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
            var path = new List<Cell> { start };
            var remainingPoints = new List<Cell>(goldenPoints);
            remainingPoints.Remove(start);

            FindShortestPath(start, remainingPoints, path, 0, shortestPath, shortestDistance);
        }

        return shortestPath;
    }

    private void FindShortestPath(Cell current, List<Cell> remainingPoints, List<Cell> path, double currentDistance, List<Cell> shortestPath, double shortestDistance)
    {
        if (remainingPoints.Count == 0)
        {
            return;
            //if (currentDistance < shortestDistance)
            //{
            //    shortestDistance = currentDistance;
            //    shortestPath = new List<Cell>(path);
            //}
        }

        foreach (var next in remainingPoints)
        {
            var distance = GetDistance(current, next);
            path.Add(next);
            var newRemainingPoints = new List<Cell>(remainingPoints);
            newRemainingPoints.Remove(next);

            FindShortestPath(next, newRemainingPoints, path, currentDistance + distance, shortestPath, shortestDistance);

            path.Remove(next);
        }
    }

    private double GetDistance(Cell a, Cell b)
    {
        return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
    }
}