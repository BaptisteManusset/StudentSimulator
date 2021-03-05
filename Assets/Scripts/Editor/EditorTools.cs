using UnityEditor;
using UnityEngine;

public class EditorTools : EditorWindow
{
  [MenuItem("Tools/EditorTools")]

  public static void ShowWindow()
  {
    EditorWindow.GetWindow(typeof(EditorTools));
  }

  void OnGUI()
  {
    GUILayout.Label("Base Settings", EditorStyles.boldLabel);
  }
}
