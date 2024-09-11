using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2;
    private Rigidbody enemyRb;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player1");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 looky = (player.transform.position - transform.position).normalized;

        enemyRb.AddForce(looky * speed);

        if(enemyRb.transform.position.y<-10)
        {
            Destroy(gameObject);
        }
    }
}
