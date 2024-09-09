using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Player;
    [SerializeField] private Vector3 offset = new Vector3(0, 5, -8);
    // Start is called before the first frame update
    

    // Update is called once per frame
    void LateUpdate()
    {
        // cemra offset
        transform.position = Player.transform.position + offset;
    }
}
