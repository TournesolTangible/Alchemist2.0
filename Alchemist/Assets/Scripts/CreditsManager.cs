using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{

    [SerializeField] private AudioSource _CreditsMusic;
    [SerializeField] private Button _BackBtn;


    void Awake() {
        _CreditsMusic.Play();
    }

    // Initiate "Go Back To Main Screen"
    public void Fire1() {
        Invoke("GoBack", .5f);
    }


    void GoBack() {
        _CreditsMusic.Stop();
        SceneManager.LoadScene(0);
    }




}
