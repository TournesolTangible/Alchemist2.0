using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornAdd : MonoBehaviour
{
    private float speed = 7;
    
    public void OnTriggerStay2D(Collider2D collider) {

        if (collider.CompareTag("Player")) {

            // if hits boxCollider destroy object 
            if (collider is BoxCollider2D) {
                Destroy(this.gameObject);
                GameManager.Instance.acornAmt += 1;
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
