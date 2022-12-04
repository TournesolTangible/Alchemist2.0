using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnvironment : MonoBehaviour
{

    [SerializeField] private List<GameObject> environment;


    void Start()
    {
        Instantiate(environment[Random.Range(0, environment.Count)], transform.position, transform.rotation);
        transform.position = new Vector2(transform.position.x, transform.position.y);

    }
}