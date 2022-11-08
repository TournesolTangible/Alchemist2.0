using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour
{

  // Not totally sure why I did this, but it works
  public ParticleSystem PS;
  private ParticleSystem CPS;

  // sound that plays on hover
  public AudioSource HoverSound;

  void Start() {
  }

  void OnMouseOver() {
    // print("Mouse Over");
    if (!CPS) {
      CPS = Instantiate(PS, this.transform);
      CPS.Play();
      this.transform.localScale = new Vector2(30, 30);
      HoverSound.Play();
    }
  }

  void OnMouseExit() {
    // print("Mouse Left");
    if (CPS) {
      Destroy(CPS);
      this.transform.localScale = new Vector2(25, 25);
    }
  }
}
