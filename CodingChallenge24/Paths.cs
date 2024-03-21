public class Paths
{
    public static (string InputFolder, string OutputFolder) LocateFolders()
    {
        var inputsCandidate = "..\\..\\..\\Inputs";
        var outputsCandidate = "..\\..\\..\\Outputs";

        if (!Directory.Exists(inputsCandidate))
            throw new Exception("Could not locate inputs folder");

        EnsureFolder(outputsCandidate);
        return (inputsCandidate, outputsCandidate);
    }

    private static void EnsureFolder(string path)
    {
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
    }

    public static IEnumerable<string> EnumerateInputs(string inputFolder)
    {
        return Directory.GetFiles(inputFolder).Where(f => !f.EndsWith("README.md"));
    }

    public static string GetFilenameInFolder(string filePath, string folder, bool insertTimestamp)
    {
        var filename = Path.GetFileName(filePath);

        if (insertTimestamp)
            filename = $"{Path.GetFileNameWithoutExtension(filename)}_{DateTime.Now:s}{Path.GetExtension(filename)}";

        return Path.Combine(folder, filename);
    }

    public static string MakeOutput(string filePath, long score, string folder)
    {
        var filename = Path.GetFileName(filePath);
        return Path.Join(folder, $"{score}_{filename}_{DateTime.Now:yyyy-MM-dd-HHmmss}.txt");
    }
}
