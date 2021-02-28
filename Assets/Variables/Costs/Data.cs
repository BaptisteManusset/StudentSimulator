using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Data : ScriptableObject
{
  public string m_name;
  [TextArea]public string description;

  [Header("Prix")]
  public float tarif = 0;

  [Header("Variable")]
  public float mental = 0;
  public float food = 0;
  public float energy = 0;
}
