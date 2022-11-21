using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance = null;

    public GameObject Player;
    public ShopScreen ShopScreen;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void RunShopScreen() {
        ShopScreen.Setup();
    }

    // to test the shop
    void Update() {
        if (Input.GetKey("o")) {
            ShopScreen.Setup();
        }
        if (Input.GetKey("p")) {
            ShopScreen.Exit();
        }
    }

}
