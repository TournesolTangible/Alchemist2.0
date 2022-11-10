using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{

    [SerializeField] private GameObject acornPrefab;

    private bool objDropped = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Projectile") && !objDropped)
        {
            // Create a location for the object we are dropping
            Vector3 location = new Vector3(Random.Range(-2.0f, 2.0f), 1, 0.0f);
            // Instantiate the new object at the location we decided relative to this object
            Instantiate(acornPrefab, transform.position + location, transform.rotation);
            // A single object has dropped, we should no longer drop any
            objDropped = true;
        }
    }
}
