using System.Text;

public class Writer
{
    public static void Write(string targetFile, Model model)
    {
        var result = new StringBuilder();

        //foreach (var snake in model.TVShows)
        //{
        //    if (snake.Locations.Count == 0 || snake.Locations.Count != snake.SegmentLength)// || snake.Score < 0)
        //    {
        //        result.AppendLine();
        //        continue;
        //    }

        //    var lastX = snake.Locations[0].x;
        //    var lastY = snake.Locations[0].y;

        //    var snakeLine = new StringBuilder();

        //    for (int i = 1; i < snake.Locations.Count; i++)
        //    {
        //        var nextX = snake.Locations[i].x;
        //        var nextY = snake.Locations[i].y;

        //        snakeLine.Append(Direction(lastX, lastY, nextX, nextY, model));

        //        if (model.IsPortal(nextX, nextY))
        //        {
        //            if (i + 1 == snake.Locations.Count)
        //            {
        //                snakeLine.Clear();
        //                break;
        //            }

        //            i++;

        //            nextX = snake.Locations[i].x;
        //            nextY = snake.Locations[i].y;

        //            var neighbors = model.Neighbors(nextX, nextY, model.Field);

        //            var worm = neighbors.Find(n => n.Value == Model.Portal);
        //            var wormIdx = neighbors.FindIndex(n => n.Value == Model.Portal);

        //            var (wormX, wormY) = model.FromIndex(worm.Index);

        //            snakeLine.Append($"{wormX} {wormY} ");

        //            snakeLine.Append(Direction(wormX, wormY, nextX, nextY, model));
        //        }

        //        lastX = nextX;
        //        lastY = nextY;
        //    }


        //    if (snakeLine.Length > 0)
        //    {
        //        result.Append(snake.Locations[0].x);
        //        result.Append(' ');
        //        result.Append(snake.Locations[0].y);
        //        result.Append(' ');
        //    }

        //    result.AppendLine(snakeLine.ToString());
        //}

        File.WriteAllText(targetFile, result.ToString());
    }


    private static string Direction(int x0, int y0, int x1, int y1, Model model)
    {
        var neighbors = model.Neighbors(x0, y0, model.Field);

        var target = model.ToIndex(x1, y1);

        var directions = new[]
        {
            "L ", "U ", "R ", "D "
        };
        return directions[neighbors.FindIndex(n => n.Index == target)];
    }
}