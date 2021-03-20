using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DevTools : MonoBehaviour
{
  [Header("[1] Tilemap")]
  public Tilemap tileMap;

  [ShowAssetPreview(128, 128)] public List<TileBase> liste;
  int countOfTiles = 0;


  [ContextMenu("Liste all Tiles in a Tilemap")]
  [Button("[1] Liste all Tiles in a Tilemap")]
  void TilemapList()
  {
    countOfTiles = 0;
    Debug.Log("<b>Liste all Tiles in a Tilemap: </b>");

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
          {
            liste.Add(slt);
            countOfTiles++;
          }
        }
      }
    }

    Debug.Log($"<b>il y a {countOfTiles} tiles.</b>");
  }

  [Header("[2] Tilemaps")]
  List<Tile> tiles;

  [Button("[2] Find missings sprite in Tiles")]
  void FindTilesWithMissingSprite()
  {
    foreach (Tile item in tiles)
    {
      bool missingSprite = false;

      if (item.sprite == null) missingSprite = true;




    }
  }




}
