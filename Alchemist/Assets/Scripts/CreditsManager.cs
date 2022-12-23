using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{

    [SerializeField] private Button _BackBtn;

    // Initiate "Go Back To Main Screen"
    public void Fire1() {
        Invoke("GoBack", 1.0f);
    }


    void GoBack() {
        SceneManager.LoadScene(0);
    }




}
