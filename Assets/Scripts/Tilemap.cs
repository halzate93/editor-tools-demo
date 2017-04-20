using UnityEngine;

public class Tilemap : MonoBehaviour 
{
	public TileArray[] tiles;
	public Tile prefab;
	
	public Tile GetTile (int x, int y)
	{
		return tiles[x][y];
	}
}
