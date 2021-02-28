using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class ClockUi : MonoBehaviour
{
  [SerializeField] Image sprite;
  [TextArea] [ReadOnly] [SerializeField] string text;

  TimeManager time;
  TMP_Text textUi;

  [SerializeField] Transform rotation;
  [SerializeField] Transform pointerHour;
  [SerializeField] Transform pointerMin;
  public float speed = 10;

  void Start()
  {
    //sprite = GetComponent<Image>();
    textUi = GetComponentInChildren<TMP_Text>();
    time = TimeManager.instance;
  }
  private void Update()
  {
    Vector3 angle = Vector3.back * 360 * ((float)time.counter) / (60 * 24);

    TimeFormating();
    //sprite.fillAmount = ((float)time.counter) / (60 * 24) % 1;
    sprite.fillAmount = TimeManager.NormalizedDayAdvancement;


    rotation.eulerAngles = angle;
    pointerHour.eulerAngles = angle * 2;
    pointerMin.eulerAngles = Vector3.back * 360 * (float)time.min / 60;

  }

  private void TimeFormating()
  {
    text = "";

    text += $"{(time.hour).ToString("d2")}:{(time.min).ToString("d2")}\n";
    text += $"{time.dayOfWeek.ToString()}\n";
    text += $"Jours n°:{time.dayCount}\n";
    text += $"{Mathf.Round(TimeManager.NormalizedDayAdvancement * 100)}%\n";

    textUi.text = text;
  }

}
