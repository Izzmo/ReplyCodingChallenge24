public class Solver3
{
    public Cell[,] Cells { get; set; }
    public List<GoldenPoint> GoldenCells { get; set; }
    public List<SilverPoint> SilverCells { get; set; }

    public Solver3(Model model)
    {
        Cells = new Cell[model.GridWidth, model.GridHeight];
        GoldenCells = model.GoldenPoints;
        SilverCells = model.SilverPoints;

        // Initialize the cells
        for (int i = 0; i < model.GridWidth; i++)
        {
            for (int j = 0; j < model.GridHeight; j++)
            {
                Cells[i, j] = new Cell { X = i, Y = j };
            }
        }

        // Mark the golden and silver cells
        foreach (var cell in GoldenCells)
        {
            Cells[cell.X, cell.Y].IsGolden = true;
        }
    }

    public List<Cell> FindShortestPath()
    {
        List<Cell> shortestPath = null;
        double shortestDistance = double.MaxValue;

        foreach (var start in GoldenCells)
        {
            var path = new List<Cell> { start };
            var remainingPoints = new List<Cell>(GoldenCells);
            remainingPoints.Remove(start);

            FindShortestPath(start, remainingPoints, path, 0, ref shortestPath, ref shortestDistance);
        }

        return shortestPath;
    }

    private void FindShortestPath(Cell current, List<Cell> remainingPoints, List<Cell> path, double currentDistance, ref List<Cell> shortestPath, ref double shortestDistance)
    {
        if (remainingPoints.Count == 0)
        {
            if (currentDistance < shortestDistance)
            {
                shortestDistance = currentDistance;
                shortestPath = new List<Cell>(path);
            }
        }
        else
        {
            foreach (var next in remainingPoints)
            {
                var distance = GetDistance(current, next);
                path.Add(next);
                var newRemainingPoints = new List<Cell>(remainingPoints);
                newRemainingPoints.Remove(next);

                FindShortestPath(next, newRemainingPoints, path, currentDistance + distance, ref shortestPath, ref shortestDistance);

                path.Remove(next);
            }
        }
    }

    private double GetDistance(Cell a, Cell b)
    {
        return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
    }
}