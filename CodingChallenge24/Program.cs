var (inputFolder, outputFolder) = Paths.LocateFolders();

Console.WriteLine("Code Challenge 2024");
Console.ForegroundColor = ConsoleColor.Blue;
Console.Write("Input:  ");
Console.ResetColor();
Console.WriteLine(inputFolder);
Console.ForegroundColor = ConsoleColor.Blue;
Console.Write("Output: ");
Console.ResetColor();
Console.WriteLine(outputFolder);

foreach (var file in Paths.EnumerateInputs(inputFolder))
{
    Console.WriteLine("--- {0}", file);

    var model = Reader.ReadModel(file);

    var solver = new Solver1();
    var shortesPath = solver.FindShortestPath(model);
    foreach (var cell in shortesPath)
    {
        Console.WriteLine($"Cell at ({cell.X}, {cell.Y})");
    }
    //Solver.Solve(model);
    var placedTiles = solver.PlaceTiles(shortesPath, model.FlattenedTiles);

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Score: {0}", model.Score);
    Console.ResetColor();

    Writer.Write(Paths.MakeOutput(file, model.Score, outputFolder), model);
}
