using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Planets : MonoBehaviour
{
    public GameObject Center_Earth;
    public GameObject Earth;
    public GameObject Jupiter;
    public float speedRotateMoon = 1f;
    public float speedRotateJupiter = 1.5f;
    public float speedRotateEarth = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Center_Earth.transform.Rotate(0, 0, speedRotateMoon * Time.deltaTime);
        Earth.transform.Rotate(0, 0, speedRotateEarth * Time.deltaTime);
        Jupiter.transform.Rotate(0, 0, speedRotateJupiter * Time.deltaTime);
        gameObject.transform.Rotate(0, 0, 0.01f * Time.deltaTime);
    }
}
