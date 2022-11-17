using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    // kill player function
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
          if (other is BoxCollider2D) {
            Destroy(other.gameObject);
          }
        }
    }

}
