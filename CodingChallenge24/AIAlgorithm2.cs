/*class GridCell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public string Value { get; set; }
    }

    class GridGraph
    {
        private int[,] distances;
        private List<GridCell>[,] grid;

        public GridGraph(int rows, int columns)
        {
            distances = new int[rows, columns];
            grid = new List<GridCell>[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    grid[i, j] = new List<GridCell>();
                }
            }
        }

        public void AddCell(GridCell cell)
        {
            grid[cell.Row, cell.Column].Add(cell);
        }

        public List<GridCell> FindPathWithMaxS(string startValue, string endValue)
        {
            List<GridCell> startCells = GetCellsByValue(startValue);
            List<GridCell> endCells = GetCellsByValue(endValue);

            List<GridCell> maxSRoute = new List<GridCell>();
            int maxSCount = -1;

            foreach (var startCell in startCells)
            {
                foreach (var endCell in endCells)
                {
                    var route = FindShortestPath(startCell, endCell);
                    int sCount = CountSInRoute(route);
                    if (sCount > maxSCount)
                    {
                        maxSRoute = route;
                        maxSCount = sCount;
                    }
                }
            }

            return maxSRoute;
        }

        private List<GridCell> FindShortestPath(GridCell start, GridCell end)
        {
            // A* Algorithm
            HashSet<GridCell> closedSet = new HashSet<GridCell>();
            HashSet<GridCell> openSet = new HashSet<GridCell> { start };
            Dictionary<GridCell, GridCell> cameFrom = new Dictionary<GridCell, GridCell>();

            Dictionary<GridCell, int> gScore = new Dictionary<GridCell, int>();
            foreach (var row in grid)
            {
                foreach (var cellList in row)
                {
                    foreach (var cell in cellList)
                    {
                        gScore[cell] = int.MaxValue;
                    }
                }
            }
            gScore[start] = 0;

            Dictionary<GridCell, int> fScore = new Dictionary<GridCell, int>();
            foreach (var row in grid)
            {
                foreach (var cellList in row)
                {
                    foreach (var cell in cellList)
                    {
                        fScore[cell] = int.MaxValue;
                    }
                }
            }
            fScore[start] = HeuristicCostEstimate(start, end);

            while (openSet.Count > 0)
            {
                GridCell current = null;
                foreach (var cell in openSet)
                {
                    if (current == null || fScore[cell] < fScore[current])
                    {
                        current = cell;
                    }
                }

                if (current == end)
                {
                    return ReconstructPath(cameFrom, current);
                }

                openSet.Remove(current);
                closedSet.Add(current);

                foreach (var neighbor in GetNeighbors(current))
                {
                    if (closedSet.Contains(neighbor))
                    {
                        continue;
                    }

                    int tentativeGScore = gScore[current] + 1; // Assuming all cells have the same distance

                    if (!openSet.Contains(neighbor))
                    {
                        openSet.Add(neighbor);
                    }
                    else if (tentativeGScore >= gScore[neighbor])
                    {
                        continue;
                    }

                    cameFrom[neighbor] = current;
                    gScore[neighbor] = tentativeGScore;
                    fScore[neighbor] = gScore[neighbor] + HeuristicCostEstimate(neighbor, end);
                }
            }

            return null; // No path found
        }

        private int HeuristicCostEstimate(GridCell current, GridCell goal)
        {
            // Manhattan distance heuristic
            return Math.Abs(current.Row - goal.Row) + Math.Abs(current.Column - goal.Column);
        }

        private List<GridCell> ReconstructPath(Dictionary<GridCell, GridCell> cameFrom, GridCell current)
        {
            List<GridCell> totalPath = new List<GridCell> { current };
            while (cameFrom.ContainsKey(current))
            {
                current = cameFrom[current];
                totalPath.Insert(0, current);
            }
            return totalPath;
        }

        private IEnumerable<GridCell> GetNeighbors(GridCell cell)
        {
            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };

            List<GridCell> neighbors = new List<GridCell>();

            foreach (var (x, y) in GetAdjacentCoordinates(cell.Row, cell.Column))
            {
                if (x >= 0 && x < grid.GetLength(0) && y >= 0 && y < grid.GetLength(1))
                {
                    foreach (var neighborCell in grid[x, y])
                    {
                        neighbors.Add(neighborCell);
                    }
                }
            }

            return neighbors;
        }

        private IEnumerable<(int, int)> GetAdjacentCoordinates(int x, int y)
        {
            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };

            for (int i = 0; i < dx.Length; i++)
            {
                yield return (x + dx[i], y + dy[i]);
            }
        }

        private List<GridCell> GetCellsByValue(string value)
        {
            List<GridCell> cells = new List<GridCell>();
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    foreach (var cell in grid[i, j])
                    {
                        if (cell.Value == value)
                        {
                            cells.Add(cell);
                        }
                    }
                }
            }
            return cells;
        }

        private int CountSInRoute(List<GridCell> route)
        {
            int count = 0;
            foreach (var cell in route)
            {
                if (cell.Value.StartsWith("S"))
                {
                    count++;
                }
            }
            return count;
        }
    }

    class Solver2
    {
        static void Main(string[] args)
        {
            // Example usage
            GridGraph graph = new GridGraph(7, 10);

            // Populate the grid
            // Assume gridCells is a list of GridCell objects containing cells with values G1, G2, G3, S1, S2, S3, and S4
            List<GridCell> gridCells = new List<GridCell>();

            // Add your grid cells to the graph
            foreach (var cell in gridCells)
            {
                graph.AddCell(cell);
            }

            // Find the route with the maximum number of S cells
            List<GridCell> maxSRouteG1ToG2 = graph.FindPathWithMaxS("G1", "G2");
            List<GridCell> maxSRouteG2ToG3 = graph.FindPathWithMaxS("G2", "G3");
            List<GridCell> maxSRouteG3ToG1 = graph.FindPathWithMaxS("G3", "G1");


        }
    }
    */