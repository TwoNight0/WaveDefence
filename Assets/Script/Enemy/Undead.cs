using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Undead : Enemy
{
    Undead()
    {
        moveSpeed = 15.0f;
    }

    

    // Start is called before the first frame update
    void Start()
    {
        target = GameManager.instance.waypoints[waypointindex];
    }

    // Update is called once per frame
    void Update()
    {
        MoveTarget(transform);
    }
}
