using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetOverlay : MonoBehaviour
{

  public static ObjetOverlay instance;


  [SerializeField] GameObject interface_E;
  private void Awake()
  {
    if (instance == null)
      instance = this;

    instance.interface_E.SetActive(false);
  }
  public static void ShowE(Interactable interactable)
  {
    instance.interface_E.transform.position = Camera.main.WorldToScreenPoint(interactable.transform.position);
    instance.interface_E.SetActive(true);
  }
  public static void HideE()
  {
    instance.interface_E.SetActive(false);
  }

}
