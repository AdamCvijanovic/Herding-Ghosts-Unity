using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class YSorterTiles : MonoBehaviour
{
    private Tilemap tilemap;
    public float muiltiplier = 0;

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);

        foreach (var position in bounds.allPositionsWithin)
        {
            int arrayIndex = position.x - bounds.x + (position.y - bounds.y) * bounds.size.x;
            TileBase tile = allTiles[arrayIndex];

            if (tile != null)
            {
                Vector3Int tilePosition = new Vector3Int(position.x, position.y, position.y); // Using Y as Z for sorting
                tilemap.SetTileFlags(tilePosition, TileFlags.None);
                tilemap.SetTile(tilePosition, tile);
                tilemap.SetTransformMatrix(tilePosition, Matrix4x4.identity);
                tilemap.GetComponent<TilemapRenderer>().sortingOrder = Mathf.RoundToInt(tilePosition.z * -500 + muiltiplier);
            }
        }
    }

    private void LateUpdate()
    {
        
    }
}

