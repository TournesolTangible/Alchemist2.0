using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;

    public void OpenPauseMenu() {

        Time.timeScale = 0f;
        pauseCanvas.SetActive(true);
    }

    public void ResumeGame() {

        Time.timeScale = 1.0f;
        pauseCanvas.SetActive(false);
    }

    public void ExitToMainMenu() {

        // Delete the player character before switching scenes
        GameObject.Destroy(GameObject.Find("GameManager").GetComponent<GameManager>().Player);

        SceneManager.LoadScene("StartScreenScene");
    }
}
