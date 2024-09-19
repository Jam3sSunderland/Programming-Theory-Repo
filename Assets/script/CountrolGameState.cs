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
   

    public void TheGameIsOver()
    {
        SceneManager.LoadScene(2);
    }
    public void ReStartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void BackToMainManu()
    {
        SceneManager.LoadScene(0);
    }
  
}
