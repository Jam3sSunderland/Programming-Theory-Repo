using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpingspider : Enemy
{
    public float jumpForce;
    public float jumpTimer;
    public float jumpRate = 2f;
    private void jumpTime()
    {
        jumpTimer += Time.deltaTime;

        if (jumpTimer > jumpRate)
        {
            jumpTimer = 0;
            Jumping();
            FollowThePlayer();
        }
    }

    
    private void Jumping()
    {
        enemyRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void Update()
    {
        jumpTime();
    }
}
