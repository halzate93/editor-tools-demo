using System;

[Serializable]
public class TileArray
{
    public Tile[] tiles;

    public Tile this [int index]
    {
        get
        {
            return tiles[index];
        }

        set
        {
            tiles[index] = value;
        }
    }

    public int Length
    {
        get
        {
            return tiles.Length;
        }
    }

    public TileArray (Tile[] tiles)
    {
        this.tiles = tiles;
    }
}