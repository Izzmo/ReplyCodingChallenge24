public struct Direction
{
    public bool Top { get; set; }
    public bool Right { get; set; }
    public bool Left { get; set; }
    public bool Bottom { get; set; }
};

public class ConnectionTiles
{
    private ConnectionTiles()
    {
        List<KeyValuePair<string, Direction>> tiles = new List<KeyValuePair<string, Direction>>
        {
            new KeyValuePair<string, Direction>("3", new Direction { Top = false, Right = true, Left = true, Bottom = false }),
            new KeyValuePair<string, Direction>("5", new Direction { Top = false, Right = true, Left = false, Bottom = true }),
            new KeyValuePair<string, Direction>("6", new Direction { Top = false, Right = false, Left = true, Bottom = true }),
            new KeyValuePair<string, Direction>("7", new Direction { Top = false, Right = true, Left = true, Bottom = true }),
            new KeyValuePair<string, Direction>("9", new Direction { Top = true, Right = true, Left = false, Bottom = false }),
            new KeyValuePair<string, Direction>("a", new Direction { Top = true, Right = false, Left = true, Bottom = false }),
            new KeyValuePair<string, Direction>("b", new Direction { Top = true, Right = true, Left = true, Bottom = false }),
            new KeyValuePair<string, Direction>("c", new Direction { Top = true, Right = false, Left = false, Bottom = true }),
            new KeyValuePair<string, Direction>("d", new Direction { Top = true, Right = true, Left = false, Bottom = true }),
            new KeyValuePair<string, Direction>("e", new Direction { Top = true, Right = false, Left = true, Bottom = true }),
            new KeyValuePair<string, Direction>("f", new Direction { Top = true, Right = true, Left = true, Bottom = true })
        };
    }

    private List<KeyValuePair<string, Direction>> tiles;
    public List<KeyValuePair<string, Direction>> Tiles { get => tiles; set => tiles = value; }
}