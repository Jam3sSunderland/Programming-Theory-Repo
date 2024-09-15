using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private string enemyName;
   [SerializeField] protected private float speed = 2;
    private float healthPoint;
    [SerializeField] private float maxHealthPoint;

    protected private Rigidbody enemyRb;
    public GameObject player;
    public float deSpawn;
    public float distance;
    
    // Start is called before the first frame update
    void Start()
    {
       
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player1");
        healthPoint = maxHealthPoint;
        Introduction();
    }

    private void Introduction()
    {
        Debug.Log("My Name is: " + enemyName + "HP:" + healthPoint + "moveSpeed:" + speed);
    }

    // Update is called once per frame
    void Update()
    {
        FollowThePlayer();
        DespawnEnemy();
       
    }
     protected virtual void FollowThePlayer()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < distance)
        {
            Vector3 looky = (player.transform.position - transform.position).normalized;

            enemyRb.AddForce(looky * speed);
        }
       
    }
    public void DespawnEnemy()
    {
        if (enemyRb.transform.position.y < deSpawn)
        {
            Destroy(gameObject);
        }
    }
}
