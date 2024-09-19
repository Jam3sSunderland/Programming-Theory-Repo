using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Image hpImage;
    public Image hpEffectImage;
    public int damage = 25;
    private PlayerMove playerHealth;
    
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
        if (healthPoint <= 0)
        {
            Death();
        }
        Attack();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            healthPoint -= 25;
        }
        DisplayHpBar();
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (playerHealth == null)
            {
                playerHealth = collision.gameObject.GetComponent<PlayerMove>();
            }
           
            playerHealth.TakeDamage(damage);
        }
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
    protected virtual void Attack()
    {
        Debug.Log(enemyName + "is Attacking");
    }
    protected virtual void Death()
    {
        Destroy(gameObject);
    }

    protected virtual void DisplayHpBar()
    {
        hpImage.fillAmount=healthPoint/maxHealthPoint;
        if (hpEffectImage.fillAmount > hpImage.fillAmount)
        {
            hpEffectImage.fillAmount -= 0.005f;
        }
        else
        {
            hpEffectImage.fillAmount = hpImage.fillAmount;
        }
    }
}
