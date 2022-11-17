using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour {

    private float speed = 7;
    
    [SerializeField] private GameManager gm;

    public void OnTriggerStay2D(Collider2D collider) {

        if (collider.CompareTag("Player")) {

            // if hits boxCollider destroy object (will need to add where to send collection here as well)
            if (collider is BoxCollider2D) {
                
                Destroy(this.gameObject);
            }

            // pull towards player if in the circleCollider
            if (collider is CircleCollider2D) {
                // speed at which magnet pulls
                float step = speed * Time.deltaTime;
                // move sprite towards the target location
                transform.position = Vector2.MoveTowards(transform.position, collider.transform.position, step); 

            }
            
            
        }

    }
}
