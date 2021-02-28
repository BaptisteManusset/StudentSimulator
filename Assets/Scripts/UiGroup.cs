using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiGroup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  [Button]
  void ResetUiMenu()
  {
    UiElement[] uiElements = GetComponentsInChildren<UiElement>();

    foreach (UiElement uiElement in uiElements)
    {
      uiElement.gameObject.SetActive(uiElement.OpenAtStart);
    }
  }
}
