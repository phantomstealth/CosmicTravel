using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform PosTarget;
    public float turnSpeed=1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position= Vector3.Lerp(transform.position, PosTarget.position, turnSpeed * Time.deltaTime);
        //transform.rotation = PosTarget.rotation;
    }
}

