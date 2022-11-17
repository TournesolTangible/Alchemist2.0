using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour {

    private float speed = 7;

    public void OnTriggerStay2D(Collider2D collider) {

        if (collider.CompareTag("Player")) {

    
            if (collider is BoxCollider2D) {
                Debug.Log("hitting box collider 2d");
                Destroy(this.gameObject);
            }
            if (collider is CircleCollider2D) {

                float step = speed * Time.deltaTime;
                // move sprite towards the target location
                transform.position = Vector2.MoveTowards(transform.position, collider.transform.position, step); 

            }
            
            
        }

    }
}
