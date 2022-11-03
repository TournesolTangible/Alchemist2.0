using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundaries : MonoBehaviour
{
    private Vector2 screen_bounds;
    private float object_width;
    private float object_height;

    void Start() {
        screen_bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        object_width = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        object_height = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }    

    void LateUpdate() {
        Vector3 view_positon = transform.position;
        view_positon.x = Mathf.Clamp(view_positon.x, screen_bounds.x * -1 + object_width, screen_bounds.x - object_width);
        view_positon.y = Mathf.Clamp(view_positon.y, screen_bounds.y * -1 + object_height, screen_bounds.y - object_height);
        transform.position = view_positon;
    }
}
