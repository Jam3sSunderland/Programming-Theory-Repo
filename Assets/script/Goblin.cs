using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy
{
    public Transform wayPoint01, wayPoint02;
    private Transform wayPointTarget;

    private void Awake()
    {
        wayPointTarget = wayPoint01;
    }
    protected override void FollowThePlayer()
    {
        base.FollowThePlayer();
        if (Vector3.Distance(transform.position, player.transform.position) > distance)
        {
            if (Vector3.Distance(transform.position, wayPoint01.position) < 1f)
            {
                wayPointTarget = wayPoint02;
            }
            if ((Vector3.Distance(transform.position, wayPoint02.position) < 1f))
            {
                wayPointTarget = wayPoint01;
            }
            transform.position = Vector3.MoveTowards(transform.position, wayPointTarget.position, speed * Time.deltaTime);

        }
    }
}
