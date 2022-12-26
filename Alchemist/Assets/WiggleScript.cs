using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiggleScript : MonoBehaviour
{
    public float amp; // amplituted of sine wave
    public float freq; // frequence of the x axis of sine wave
    Vector3 initPos; // inital position

    private void Start() {
      initPos = transform.position;
    }

    private void Update() {
      transform.position = new Vector3(Mathf.Sin(Time.time * freq) * amp + initPos.x, initPos.y, 0);
    }
}
