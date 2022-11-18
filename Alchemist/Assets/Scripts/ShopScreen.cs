using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScreen : MonoBehaviour
{
   

   public void Setup() {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Exit() {
        // Resume game - unpause
        Time.timeScale = 1;
        // Close the ShopScreen
        gameObject.SetActive(false);
    }
}
