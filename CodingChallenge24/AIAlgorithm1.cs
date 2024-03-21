public class Cell
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsGolden { get; set; }
    public bool IsSilver {get; set;}
}

public class Solver1
{
    public Cell[,] Cells { get; set; }

    public Dictionary<Cell, List<Cell>> FindShortestPaths(Model model)
    {
        Cells = new Cell[model.GridWidth, model.GridHeight];

        // Initialize the cells
        for (int i = 0; i < model.GridWidth; i++)
        {
            for (int j = 0; j < model.GridHeight; j++)
            {
                Cells[i, j] = new Cell { X = i, Y = j };
            }
        }

        var paths = new Dictionary<Cell, List<Cell>>();

        for (int i = 0; i < model.GoldenPoints.Count; i++)
        {
            for (int j = i + 1; j < model.GoldenPoints.Count; j++)
            {
                var path = FindShortestPath(model.GoldenPoints[i], model.GoldenPoints[j]);
                if (path != null)
                {
                    paths.Add(model.GoldenPoints[i], path);
                }
            }
        }

        return paths;
    }

    public List<Cell> FindShortestPath(Cell start, Cell end)
    {
        var visited = new bool[Cells.GetLength(0), Cells.GetLength(1)];
        var queue = new Queue<Cell>();
        var path = new Dictionary<Cell, Cell>();

        visited[start.X, start.Y] = true;
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            var cell = queue.Dequeue();

            if (cell.X == end.X && cell.Y == end.Y)
            {
                var shortestPath = new List<Cell>();
                while (cell != null)
                {
                    shortestPath.Add(cell);
                    path.TryGetValue(cell, out cell);
                }
                shortestPath.Reverse();
                return shortestPath;
            }

            foreach (var neighbour in GetNeighbours(cell))
            {
                if (!visited[neighbour.X, neighbour.Y])
                {
                    visited[neighbour.X, neighbour.Y] = true;
                    queue.Enqueue(neighbour);
                    if (!path.ContainsKey(neighbour))
                    {
                        path.Add(neighbour, cell);
                    }
                }
            }
        }

        return null; // No path found
    }

    private IEnumerable<Cell> GetNeighbours(Cell cell)
    {
        var neighbours = new List<Cell>();

        if (cell.X > 0) neighbours.Add(Cells[cell.X - 1, cell.Y]);
        if (cell.Y > 0) neighbours.Add(Cells[cell.X, cell.Y - 1]);
        if (cell.X < Cells.GetLength(0) - 1) neighbours.Add(Cells[cell.X + 1, cell.Y]);
        if (cell.Y < Cells.GetLength(1) - 1) neighbours.Add(Cells[cell.X, cell.Y + 1]);

        return neighbours.Where(x => x.IsGolden);
    }
}