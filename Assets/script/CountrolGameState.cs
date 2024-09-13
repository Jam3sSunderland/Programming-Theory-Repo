using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountrolGameState : MonoBehaviour
{
    public float shotRate = 2;
    public float shotTimer;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    public void TheGameIsOver()
    {
        SceneManager.LoadScene(2);
    }
    private void Attack()
    {
        shotTimer += Time.deltaTime;
        if (shotTimer > shotRate)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            shotTimer = 0;
        }
    }
}
