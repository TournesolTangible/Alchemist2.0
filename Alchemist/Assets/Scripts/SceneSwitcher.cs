using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
  public Button btn1;
  public Button btn2;
  [SerializeField] float moveSpeed;
  private bool fired;

  void Start() {
    fired = false;
  }

  void Update() {
    // if (fired) {
    //   btn1.transform.position += transform.right * moveSpeed * Time.deltaTime;
    //   print(transform.right * moveSpeed * Time.time);
    // }
  }


  // if (GameManager.instance.player) { // null ref check
  //           transform.LookAt(GameManager.instance.player.transform.position); // Look at the player
  //           transform.position += transform.forward * moveSpeed * Time.deltaTime;
  //       }

  // 'Fires' the function of this button
  public void Fire() {
    FlyAway();
    Invoke("ChangeScene", 2.0f);
  }

  private void FlyAway() {
    fired = true;
  }

  // Changes scene to 'next in scene' or - gameplay
  public void ChangeScene() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
  }
}
