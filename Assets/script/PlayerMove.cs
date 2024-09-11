using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float horsePower = 0;
    public float turnSpeed = 45.0f;
    public float forWardInput;
    public float horizontalInput;
    public float speed;
    private Rigidbody playerRB;
    // Start is called before the first frame update
    void Start()
    {
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
    }
}
