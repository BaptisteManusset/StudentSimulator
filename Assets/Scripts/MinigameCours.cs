using DG.Tweening;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameCours : MonoBehaviour
{
  [Header("Time")]
  [ProgressBar("Duration", 10)]
  public float duration = 10;
  public float durationMax = 10;
  [Header("References elements ")] [SerializeField] Color[] colors;
  [SerializeField] List<Image> images;

  [Foldout("Elements")] [SerializeField] Image image;
  [Foldout("Elements")] [SerializeField] Image bulle;
  [Foldout("Elements")] [SerializeField] Image prof;




  [SerializeField] int select;


  public enum MGStat
  {
    none = -1,
    start = 0,
    play = 1,
    end = 2,
    pause = 3,
    countdown = 4,
    win = 10,
    lost = 9
  }

  [ReadOnly]
  public MGStat miniGameStat = MGStat.none;

  [SerializeField]
  private float shakeStrenght = 10;
  [SerializeField] private float shakeDuration = 1;

  void Start() => miniGameStat = MGStat.start;


  private void Update()
  {

    switch (miniGameStat)
    {
      default:
      case MGStat.none:
        break;

      case MGStat.start:
        colors.Shuffle();

        for (int i = 0; i < images.Count; i++)
        {
          images[i].color = colors[i];
        }


        select = Random.Range(0, images.Count);


        image.color = colors[select];
        duration = 10;
        durationMax = duration;

        bulle.gameObject.SetActive(true);


        miniGameStat = MGStat.play;
        break;


      case MGStat.play:

        #region Timer
        duration -= Time.deltaTime;
        #endregion


        #region UI
        image.fillAmount = duration / durationMax;
        #endregion


        if (duration <= 0) miniGameStat = MGStat.lost;
        break;



      case MGStat.win:



        miniGameStat = MGStat.end;
        break;

      case MGStat.lost:

        DoShake();
        miniGameStat = MGStat.end;
        break;


      case MGStat.end:
        image.fillAmount = 0;


        bulle.gameObject.SetActive(false);

        miniGameStat = MGStat.countdown;
        StartCoroutine(nameof(CountDownRestart));
        break;
    }
  }


  IEnumerator CountDownRestart()
  {
    yield return new WaitForSeconds(1);
    miniGameStat = MGStat.start;
  }



  [ContextMenu("New select")]
  private void StartMiniGame() => miniGameStat = MGStat.start;




  public void ClickedButton(int id)
  {

    if (miniGameStat != MGStat.play) return;

    if (select == id)
    {
      Debug.Log("Sucess");

      miniGameStat = MGStat.win;

    } else
    {
      miniGameStat = MGStat.lost;

      DoShake();
      Debug.Log("Fail");
    }
  }

  private void DoShake()
  {

    SoundManager.PlayMusic("bipError");
    bulle.transform.DOShakePosition(shakeDuration, strength: shakeStrenght);
    prof.transform.DOShakePosition(shakeDuration, strength: shakeStrenght);
  }
}
