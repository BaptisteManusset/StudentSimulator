using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DevTools : MonoBehaviour
{

  public Tilemap tileMap;

  [ShowAssetPreview(128, 128)] public List<TileBase> liste;

  [ContextMenu("TilemapList")]
  void TilemapList()
  {
    liste.Clear();
    for (int n = tileMap.cellBounds.xMin; n < tileMap.cellBounds.xMax; n++)
    {
      for (int p = tileMap.cellBounds.yMin; p < tileMap.cellBounds.yMax; p++)
      {

        Vector3Int localPlace = (new Vector3Int(n, p, (int)tileMap.transform.position.y));
        Vector3 place = tileMap.CellToWorld(localPlace);


        TileBase slt = tileMap.GetTile(localPlace);



        if (slt)
        {
          Debug.Log($"Tiles:{slt} localPlace:{localPlace} place:{place}");
          if (!liste.Contains(slt))
            liste.Add(slt);
        }
      }
    }
  }
}
