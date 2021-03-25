using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetOverlay : MonoBehaviour
{

  public static ObjetOverlay instance;
  Interactable actualInteractable;

  [SerializeField] GameObject interface_E;
  private void Awake()
  {
    if (instance == null)
      instance = this;

    instance.interface_E.SetActive(false);
  }
  public static void ShowE(Interactable interactable)
  {

    instance.actualInteractable = interactable;
    instance.interface_E.transform.position = Camera.main.WorldToScreenPoint(instance.actualInteractable.transform.position);
    instance.interface_E.SetActive(true);
    instance.actualInteractable = null;
  }
  public static void HideE()
  {
    instance.interface_E.SetActive(false);
  }


}
