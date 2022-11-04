using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndDestroyLevelPart : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    private Vector2 screenBounds;

    void Start () {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update() {
        transform.Translate(Vector2.left * Time.deltaTime * speed);

        if(transform.position.x < screenBounds.x * -4){
            Destroy(this.gameObject);
        }
    }

    
}

