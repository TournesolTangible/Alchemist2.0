using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnalivePlayer : MonoBehaviour
{
    private bool _Unalive = false;

    [SerializeField] private float _ScaleMod;
    private Vector2 _PlayerScale;

    [SerializeField] private float amp; // amplituted of sine wave
    [SerializeField] private float freq; // frequence of the axis of sine wave
    private Vector2 initPos; // inital position

    void Update()
    {
        if (_Unalive) {

            if (this.transform.localScale.x > 0) {
                this.transform.localScale = new Vector2(this.transform.localScale.x - _ScaleMod, this.transform.localScale.y - _ScaleMod);
                this.transform.position = new Vector2(Mathf.Sin(Time.unscaledTime * freq) * amp + initPos.x, initPos.y);
            }

                
        }
    }

    public void Died() {

        // player unalived
        _Unalive = true;
        // player scale squish (called in update after)

        // set player's initial position on death
        initPos = this.transform.position;

        // pause timeScale
        Time.timeScale = 0;

        // play death sound
        // switch to Main Screen
        // (The GameManager checks for these and handles it on its own)
        
    }

    public bool isAlive() {
        return !_Unalive;
    }
}
