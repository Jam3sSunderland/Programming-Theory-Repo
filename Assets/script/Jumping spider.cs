using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpingspider : Enemy
{
    public float jumpForce;
    public float jumpTimer;
    public float jumpRate = 2f;




    protected override void FollowThePlayer()
    {
        //base.FollowThePlayer();
        JumpTime();
    }
    private void JumpTime()
    {
        jumpTimer += Time.deltaTime;

        if (jumpTimer > jumpRate)
        {
            jumpTimer = 0;
            Jumping();
            FollowThePlayerJumping();
        }
    }

    
    private void Jumping()
    {
        enemyRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void FollowThePlayerJumping()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < distance)
        {
            Vector3 looky = (player.transform.position - transform.position).normalized;

            enemyRb.AddForce(looky * speed);
        }
    }

   
}
