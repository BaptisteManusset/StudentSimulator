//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor;
//using UnityEditorInternal;
//using UnityEngine;

//public class AudioLibraryEditor : Editor
//{
//  private ReorderableList list;

//  private void OnEnable()
//  {
//    list = new ReorderableList(serializedObject,
//            serializedObject.FindProperty("textToMusics"),
//            true, true, true, true);
//  }

//  public override void OnInspectorGUI()
//  {
//    serializedObject.Update();
//    list.DoLayoutList();
//    serializedObject.ApplyModifiedProperties();
//  }
//}
