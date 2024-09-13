using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2;
    protected private Rigidbody enemyRb;
    public GameObject player;
    public float deSpawn;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player1");
    }

    // Update is called once per frame
    void Update()
    {
        FollowThePlayer();
        DespawnEnemy();
       
    }
     protected virtual void FollowThePlayer()
    {
        Vector3 looky = (player.transform.position - transform.position).normalized;

        enemyRb.AddForce(looky * speed);
    }
    public void DespawnEnemy()
    {
        if (enemyRb.transform.position.y < deSpawn)
        {
            Destroy(gameObject);
        }
    }
}
