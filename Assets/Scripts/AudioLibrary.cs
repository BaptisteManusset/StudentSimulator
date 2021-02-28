using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AudioLibrary : ScriptableObject
{
  public List<TextToMusic> textToMusics;
}


[Serializable]
public class TextToMusic
{
  public string key;
  public List<AudioClip> audioclips;
}
