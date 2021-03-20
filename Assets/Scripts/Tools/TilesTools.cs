using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilesTools : EditorWindow
{

  List<Tile> errorTiles;



  string guid = "";
  string path = "";
  [MenuItem("Tools/Dev Tools")]
  static void CreateWindow()
  {
    TilesTools window = (TilesTools)EditorWindow.GetWindowWithRect(typeof(TilesTools), new Rect(0, 0, 400, 120));
  }


  int toolbarInt = 0;
  string[] toolbarStrings = { "GUID to Asset Path", "Toolbar2", "Toolbar3" };



  Vector2 scrollPos;
  void OnGUI()
  {
    toolbarInt = GUILayout.Toolbar(toolbarInt, toolbarStrings);

    switch (toolbarInt)
    {
      case 0:
      default:
        GUIDToPath();

        break;
      case 1:
        if (GUILayout.Button("List tiles missing sprite"))
          errorTiles = ListTiles();

        scrollPos =
           EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Height(800));

        foreach (Tile item in errorTiles)
        {
          GUILayout.BeginHorizontal();
          EditorGUILayout.ObjectField(item, typeof(Tile), false, GUILayout.Width(30));
          GUILayout.Label($"{item.name}", GUILayout.Width(200));
          GUILayout.Label($"{item.GetInstanceID()}");
          EditorGUILayout.ObjectField(item.sprite, typeof(Sprite), false);





          GUILayout.EndHorizontal();

        }
        EditorGUILayout.EndScrollView();


        break;
      case 2:

        break;
    }

  }

  private void GUIDToPath()
  {
    GUILayout.Label("Enter guid");
    guid = GUILayout.TextField(guid);
    GUILayout.BeginHorizontal();
    GUILayout.FlexibleSpace();
    if (GUILayout.Button("Get Asset Path", GUILayout.Width(300)))
      path = GetAssetPath(guid);
    GUILayout.FlexibleSpace();
    GUILayout.EndHorizontal();

  }

  static string GetAssetPath(string guid)
  {
    string path = AssetDatabase.GUIDToAssetPath(guid);
    Object obj = AssetDatabase.LoadAssetAtPath(path, typeof(Object));

    Selection.activeObject = obj;

    if (path.Length == 0) path = "not found";
    return path;
  }

  List<Tile> ListTiles()
  {
    errorTiles.Clear();
    List<Tile> list = new List<Tile>();

    string[] guids1 = AssetDatabase.FindAssets("t:tile", new[] { "Assets/8x8Palette" });

    foreach (string guid1 in guids1)
    {
      var path = AssetDatabase.GUIDToAssetPath(guid1);
      Tile tile = AssetDatabase.LoadAssetAtPath<Tile>(path);

      if (!tile.sprite)
        list.Add(tile);

      //Debug.Log($"<{guid1}> {AssetDatabase.GUIDToAssetPath(guid1)} Sprite:<b> {tile.sprite} </b>");
      //modify prefab
      //AssetDatabase.SaveAssets();
    }

    return list;

  }
}
