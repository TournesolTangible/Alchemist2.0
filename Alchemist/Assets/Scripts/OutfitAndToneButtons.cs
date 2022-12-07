using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutfitAndToneButtons : MonoBehaviour
{

    // MouseOver variables
    public AudioSource HoverSound;
    public ParticleSystem PS;
    private ParticleSystem CPS;
    public Image Bilby;

    // Waveform variables
    public float amp; // amplituted of sine wave
    public float freq; // frequence of the x axis of sine wave
    Vector3 initPos; // inital position

    private void Start() {
       initPos = this.transform.position;
    }

     private void Update() {
        PS.transform.position = new Vector3(initPos.x, Mathf.Cos(Time.time * freq) * amp + initPos.y, 0);
    }


    void OnMouseOver() {
        // print("Mouse Over");
        if (!CPS) {
            CPS = Instantiate(PS, this.transform);
            //CPS.Play();
            this.transform.localScale = new Vector2(1.25f, 1.25f);
            HoverSound.Play();
        }
    }


    void OnMouseExit() {
        // print("Mouse Left");
        if (CPS) {
            Destroy(CPS);
            this.transform.localScale = new Vector2(1, 1);
        }
        
    }
}
