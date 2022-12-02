using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public Text timerText;
    private float seconds;
    private int minutes;
    private int hours;

    void Update() {

        TimerDisplay();
    }

    public void TimerDisplay() {

        seconds += Time.deltaTime;
        timerText.text = hours + "h : "+ minutes +"m : " + (int)seconds + "s";
        if (seconds >= 60) {
            minutes++;
            seconds = 0;
        } 
        else if (minutes >= 60) {
            hours++;
            minutes = 0;
        }    
    }
}
