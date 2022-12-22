using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour
{

  public ParticleSystem PS;
  private ParticleSystem CPS; // Current Particle System (active in scene, not instantiated until mouseOver() )


  // sound that plays on hover
  public AudioSource HoverSound;


  void Start() {
  }

  void OnMouseOver() {
    if (!CPS) {
      CPS = Instantiate(PS, transform);
      CPS.Play();
      this.transform.localScale = new Vector2(40, 40);
      HoverSound.Play();
    }
  }

  void OnMouseExit() {
    if (CPS) {
      Destroy(CPS);
      this.transform.localScale = new Vector2(30, 30);
    }
  }
}
