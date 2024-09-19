using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerMove : MonoBehaviour
{
    public int playerHealthPoint;
    public int maxHealthPoint;

    public float m_HorsePower = 0.5f;
    public float HorsePower //ENCAPSULATION
    {
        get { return m_HorsePower; }
        set
        { 
            if (value < 0.0f)
            {
                Debug.LogError("you cant set a negative horsepower");
            }
            else
            {
                m_HorsePower = value;
            }
        }

    }


    public float turnSpeed = 45.0f;
    public float forWardInput;
    public float horizontalInput;
    public float speed;
    private Rigidbody playerRB;

    public Slider slider;
    public float outOfBounds { get; private set; } = -0.4f;//ENCAPSULATION
    private CountrolGameState gameState;

   
    // Start is called before the first frame update
    void Start()
    {
        gameState = GameObject.Find("GameBrain").GetComponent<CountrolGameState>();
        playerRB = GetComponent<Rigidbody>();
        playerHealthPoint = maxHealthPoint;
        slider.maxValue = maxHealthPoint;
        slider.value = playerHealthPoint;
    }

   

    // Update is called once per frame
    void FixedUpdate()
    { 

        horizontalInput = Input.GetAxis("Horizontal");
        forWardInput = Input.GetAxis("Vertical");
        // move car
        //  transform.Translate(Vector3.forward *Time.deltaTime*speed * forWardInput);
        playerRB.AddRelativeForce(Vector3.forward * m_HorsePower * forWardInput);
        // rotate car 
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput );

        speed = Mathf.RoundToInt(playerRB.velocity.magnitude * 2.237f);

        //hp player
        






        //game over from falling 
        OutOfBoundsPlayer();
    }
    public void TakeDamage(int amount)
    {
        playerHealthPoint -= amount;
        slider.value = playerHealthPoint;
        if (playerHealthPoint <= 0)
        {
            Death();
        }
    }


   

 



    private void OutOfBoundsPlayer()
    {
        if (transform.position.y < outOfBounds)
        {
            
          gameState.TheGameIsOver();
            //Destroy(gameObject);
          
        }

    }
    private void Death()
    {
        gameState.TheGameIsOver();
    }
   

}
