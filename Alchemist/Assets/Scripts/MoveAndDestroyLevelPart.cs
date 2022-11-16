using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndDestroyLevelPart : MonoBehaviour
{
    [SerializeField] private float speed = 4.0f;
    private Vector2 screenBounds;

    void Start () {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update() {
        // moves platforms from right to left at a set speed
        transform.Translate(Vector2.left * Time.deltaTime * speed);

        // destroys platforms off screen
        if(transform.position.x < screenBounds.x * -5){
            Destroy(this.gameObject);
        }
    }
}

