using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ControlByLight : MonoBehaviour
{
  //[SerializeField] [MinMaxSlider(0, 1)] Vector2 limit;
  Light2D light;
  [SerializeField] Light2D master;
  public float breakpoint;
  public bool forceOff = false;

  void Start()
  {
    light = GetComponent<Light2D>();
  }

  // Update is called once per frame
  void Update()
  {
    //light.enabled = (TimeManager.NormalizedDayAdvancement < limit.x || TimeManager.NormalizedDayAdvancement > limit.y) && !forceOff;
    light.enabled = (master.intensity <= breakpoint) && !forceOff;
  }


  public void Open() => forceOff = false;
  public void Close() => forceOff = true;
}
