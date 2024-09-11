using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public Transform camTarget;
    public float pLerp = 0.2f;
    public float rLerp = 0.1f;

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, camTarget.position, pLerp );
        transform.rotation = Quaternion.Lerp(transform.rotation, camTarget.rotation, rLerp );
    }
}
