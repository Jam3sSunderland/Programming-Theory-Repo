using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TheWizerd : Enemy
{
    private float moveRate = 2;
    private float moverTimer;
    public float shotRate = 2.1f;
    public float shotTimer;
    public GameObject projectile;

    [SerializeField] private float minX, maxX, minZ, maxZ;



    protected override void FollowThePlayer()
    {
        base.FollowThePlayer();
        RandomMover();
    }

    private void RandomMover()
    {
        moverTimer += Time.deltaTime;

        if (moverTimer > moveRate)
        {
           // Attack();
            transform.position = new Vector3(Random.Range(minX, maxX), 1.11f, Random.Range(minZ, maxZ));
            
            moverTimer = 0;
            

        }
    }
    protected override void Attack()
    {
        base.Attack();
        shotTimer += Time.deltaTime;
        if (shotTimer > shotRate)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            shotTimer = 0;
        }
    }
}
