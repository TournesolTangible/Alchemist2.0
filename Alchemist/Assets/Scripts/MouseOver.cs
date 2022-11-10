using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour
{

  public ParticleSystem PS;
  private ParticleSystem CPS; // Current Particle System (active in scene, not instantiated until mouseOver() )

  public AudioSource hoverSound;

  void Start() {
  }

  void OnMouseOver() {
    print("Mouse Over");
    if (!CPS) {
      CPS = Instantiate(PS, this.transform);
      CPS.Play();
      hoverSound.Play();
    }
  }

  void OnMouseExit() {
    print("Mouse Left");
    if (CPS) {
      Destroy(CPS);
    }
  }
}
