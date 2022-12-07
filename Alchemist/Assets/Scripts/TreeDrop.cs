using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDrop : MonoBehaviour
{
    [SerializeField] private float enemyMaxHealth = 3.0f;
    private float enemyCurrentHealth;

    [SerializeField] private GameObject collectable;
    [SerializeField] private GameObject heart;

    // Reference to GameManager to moderate drop amount (stats)
    private static GameObject GameManager;

    private bool dropped = false;

    void Awake()
    {
        GameManager = GameObject.Find("GameManager");
    }

    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
    }

    void Update()
    {
        if (enemyCurrentHealth <= 0)
        {
            int random_number = Random.Range(0,20); // ganerates a random number between 1 to 10
            random_number += GameManager.GetComponent<GameManager>().playerLuck; // Add player luck to 'random_number'
            if (random_number >= 19 && !dropped)
            { // if roll is >= 10 get 3 collectables
                Instantiate(collectable, transform.position, new Quaternion(0, 0, 0, 0));
                dropped = true;
            }
            if (17 < random_number && !dropped)
            { // if roll is greater than 7 get 2 collectables
                Instantiate(collectable, transform.position, new Quaternion(0, 0, 0, 0));
                dropped = true;
            }
            if (15 < random_number && !dropped)
            { // if roll is greater than 4 get 1 collectable
                Instantiate(collectable, transform.position, new Quaternion(0, 0, 0, 0));
                dropped = true;
            } // if roll is 15 or less get nothing
            else
            {
                dropped = true;
            }

        }
    }

    // take damage
    public void TakeDamage(float damage)
    {
        enemyCurrentHealth -= damage;
    }

}

