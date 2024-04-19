using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRotate : MonoBehaviour
{
    private Rigidbody myRigBody;
    public float speedRotation = 2.5f;
    public float speedMove = 4f;
    // Start is called before the first frame update
    void Start()
    {
        myRigBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 0, speedRotation * Time.deltaTime);
        myRigBody.velocity = transform.forward * speedMove;
    }
}
