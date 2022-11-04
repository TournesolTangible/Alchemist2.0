using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatScript : MonoBehaviour
{

  public float amp; // amplituted of sine wave
  public float freq; // frequence of the x axis of sine wave
  Vector3 initPos; // inital position

  private void Start() {
    initPos = transform.position;
  }

  private void Update() {
    transform.position = new Vector3(initPos.x, Mathf.Sin(Time.time * freq) * amp + initPos.y, 0);
  }
}
