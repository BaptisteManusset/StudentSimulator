using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour
{
  public void Close() => gameObject.SetActive(false);
  public void Open() => gameObject.SetActive(true);
}
