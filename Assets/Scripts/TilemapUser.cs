using UnityEngine;

public class TilemapUser: MonoBehaviour
{
    [SerializeField]
    private Tilemap tilemap;

    private void Update ()
    {
        if (Input.GetKeyDown (KeyCode.Space))
            Debug.Log (tilemap.GetTile (0, 0));
    }
}