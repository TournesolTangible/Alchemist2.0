using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AStarUpdate : MonoBehaviour
{

    // update the A* graph during runtime
    void Update()
    {
        AstarPath.active.Scan();
    }
}
