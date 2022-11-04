using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float SPAWN_LEVEL_DISTANCE = 40.0f;

    [SerializeField] private Transform level_start;
    [SerializeField] private List<Transform> level_part_list;
    [SerializeField] private Player player;

    private Vector3 last_end_position;
    
    private void Awake() {
        last_end_position = level_start.Find("EndPosition").position;
        
        // number of starting level pieces spawned
        int starting_spawned_pieces = 2;
        for (int i = 0; i < starting_spawned_pieces; i++){
            SpawnLevelPart();
        }
    }

    private void Update() {
        if (Vector3.Distance(player.transform.position, last_end_position) < SPAWN_LEVEL_DISTANCE) {
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart() {
        Transform random_level_part = level_part_list[Random.Range(0, level_part_list.Count)];
        Transform last_level_part_transform = SpawnLevelPart(random_level_part, last_end_position);
        last_end_position = last_level_part_transform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart (Transform level_part, Vector3 spawn_position) {
        Transform level_part_transform = Instantiate(level_part, spawn_position, Quaternion.identity);
        return level_part_transform;
    }
}
