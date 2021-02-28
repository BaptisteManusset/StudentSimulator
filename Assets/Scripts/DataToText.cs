using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class DataToText : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{

  [SerializeField] TMP_Text displayText;
  Interactable interactable;

  void Awake()
  {
    //displayText = GetComponentInChildren<TMP_Text>();
    interactable = GetComponent<Interactable>();
  }

  private void GenerateAndDisplayText()
  {
    string text = "";
    text += $"<size=150%>{interactable.data.m_name}</size>\n";
    text += $"{interactable.data.tarif}€\n";
    text += $"Mental: {interactable.data.mental}\n";
    text += $"Food: {interactable.data.food}\n";
    text += $"Energy: {interactable.data.energy}\n";
    text += $"<b>{interactable.data.description}</b>";

    displayText.text = text;
  }

  public void OnPointerEnter(PointerEventData eventData)
  {
    GenerateAndDisplayText();
  }

  public void OnPointerExit(PointerEventData eventData)
  {
    Debug.Log("Quit");
    displayText.text = "";
  }

  public void OnPointerDown(PointerEventData eventData)
  {
    //throw new System.NotImplementedException();
  }
}
