using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Enemy
{
    private float moveRate = 2;
    private float moverTimer;
    private PlayerMove playerMoveScript;

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
            Destroy(gameObject);

        }
    }
   
    protected override void DisplayHpBar()
    {
        //base.DisplayHpBar();
    }
   
}
