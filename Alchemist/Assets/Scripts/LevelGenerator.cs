using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
   
    [SerializeField] private Transform level_start;
    [SerializeField] private List<Transform> level_part_list;

    private Vector2 screen_bounds;
    private Vector3 last_end_position;
    Transform last_level_part_transform;
    
    private void Awake() { 
        // get the starting end position
        last_end_position = level_start.Find("EndPosition").position;

        // number of starting level pieces spawned
        int starting_spawned_pieces = 3;
        for (int i = 0; i < starting_spawned_pieces; i++){
            SpawnLevelPart();
        }
    }

    void Start () {
        // get camera bounds for generation
        screen_bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void Update() {
        // update the last end position as it comes towards the screen
        last_end_position = last_level_part_transform.Find("EndPosition").position;
       
       // if the end position is less than 2x the screen bounds create another piece
        if (last_end_position.x < screen_bounds.x * 2){
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart() {
        Transform random_level_part = level_part_list[Random.Range(0, level_part_list.Count)];
        last_level_part_transform = SpawnLevelPart(random_level_part, last_end_position);
        last_end_position = last_level_part_transform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart (Transform level_part, Vector3 spawn_position) {
        Transform level_part_transform = Instantiate(level_part, spawn_position, Quaternion.identity);
        return level_part_transform;
    }
}
