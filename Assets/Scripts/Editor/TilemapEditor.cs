#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor (typeof (Tilemap))]
public class TilemapEditor : Editor
{
	private Tilemap tilemap;
	private int width;
	private int height;

	private void OnEnable ()	
	{
		tilemap = (Tilemap) target;
		height = tilemap.tiles.Length;
		width = (height > 0)? tilemap.tiles[0].Length : 0;
	}

	public override void OnInspectorGUI ()
	{
		// DrawDefaultInspector ();
		// DrawPropertiesExcluding (serializedObject, "tiles");
		DrawSize ();
		tilemap.prefab = (Tile) EditorGUILayout.ObjectField ("Prefab", tilemap.prefab, typeof (Tile), false);
		if (GUILayout.Button ("Create"))
		{
			DestroyLastTiles ();
			CreateNewTiles ();
		}
	}

	private void DrawSize ()
	{
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.LabelField ("Size", GUILayout.MaxWidth (50));
		width = EditorGUILayout.IntField (width);
		height = EditorGUILayout.IntField (height);
		EditorGUILayout.EndHorizontal ();
	}

	private void DestroyLastTiles ()
	{
		while (tilemap.transform.childCount > 0)
			DestroyImmediate (tilemap.transform.GetChild (0).gameObject);
	}

	private void CreateNewTiles ()
	{
		if (tilemap.prefab == null)
			return;
		TileArray[] tiles = new TileArray[height];
		for (int y = 0; y < height; y++)
		{
			TileArray row = new TileArray (new Tile[width]);
			for (int x = 0; x < width; x++)
			{
				row[x] = GameObject.Instantiate (tilemap.prefab, new Vector3 (x, y, 0f), Quaternion.identity, tilemap.transform);
				row[x].gameObject.name = string.Format ("Tile {0} {1}", x, y);
			}
			tiles[y] = row;
		}
		tilemap.tiles = tiles;
	}
}
#endif