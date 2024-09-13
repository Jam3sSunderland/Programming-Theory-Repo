using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float horsePower = 0;
    public float turnSpeed = 45.0f;
    public float forWardInput;
    public float horizontalInput;
    public float speed;
    private Rigidbody playerRB;
    private float outOfBounds = -0.4f;
    private CountrolGameState gameState;
    // Start is called before the first frame update
    void Start()
    {
        gameState = GameObject.Find("GameBrain").GetComponent<CountrolGameState>();
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forWardInput = Input.GetAxis("Vertical");
        // move car
        //  transform.Translate(Vector3.forward *Time.deltaTime*speed * forWardInput);
        playerRB.AddRelativeForce(Vector3.forward * horsePower * forWardInput);
        // rotate car 
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput );

        speed = Mathf.RoundToInt(playerRB.velocity.magnitude * 2.237f);

        //game over from falling 
        OutOfBoundsPlayer();
    }
    private void OutOfBoundsPlayer()
    {
        if (transform.position.y < outOfBounds)
        {
            
          gameState.TheGameIsOver();
            //Destroy(gameObject);
          
        }

    }
   

}
