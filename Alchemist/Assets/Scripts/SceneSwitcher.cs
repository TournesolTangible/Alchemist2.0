using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

  // 'Fires' the function of this button
  public void Fire() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
  }
}
