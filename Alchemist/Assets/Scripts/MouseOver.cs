using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour
{
  public ParticleSystem PS;

  private ParticleSystem CPS;

  void Start() {
  }

  void OnMouseOver() {
    print("Mouse Over");
    if (!CPS) {
      CPS = Instantiate(PS, this.transform);
      CPS.Play();
    }
  }

  void OnMouseExit() {
    print("Mouse Left");
    if (CPS) {
      Destroy(CPS);
    }
  }
}
