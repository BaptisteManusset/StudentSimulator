using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour
{
  public void Close()
  {
    gameObject.SetActive(false);
    SoundManager.PlayMusic("click");
  }
  public void Open()
  {
    gameObject.SetActive(true);
    SoundManager.PlayMusic("click");
  }
}
