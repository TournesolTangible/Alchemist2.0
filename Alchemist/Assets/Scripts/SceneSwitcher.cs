using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
  public Button btn1;
  public Button btn2;

  public AudioSource CHIPTUNA;
  public AudioSource Confirm;


  void Start() {

    Time.timeScale = 1;

    //TODO
    // Uncomment this to play music on startup
    // CHIPTUNA.Play();
    //
  }

  void Update() {
  }

  // Starts the game after delay of ~1s
  public void Fire1() {
    Confirm.Play();
    Invoke("ChangeScene", 1.0f);
  }

  // Exits the game on press
  public void Fire2() {
    Confirm.Play();
    Invoke("CloseGame", 1.0f);
  }

  // Changes scene to 'next in scene' or - gameplay
  public void ChangeScene() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
  }

  // Exits the game
  public void CloseGame() {
    Application.Quit();
  }
}
