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
    //Solver.Solve(model);

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Score: {0}", model.Score);
    Console.ResetColor();

    Writer.Write(Paths.MakeOutput(file, model.Score, outputFolder), model);
}
