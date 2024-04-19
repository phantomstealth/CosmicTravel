using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float vspeed;
    public float hspeed;
    public float rspeed;
    public float maxSpeed = 20f;
    public float currentSpeed;
    public float moveSpeedUP = 2f;
    public float speedBrakeShip = 1.5f;
    public Slider sliderSpeedPlayer;
    public float turnSpeed = 0.05f;
    private Rigidbody myRigidBody;
    public Camera mainCamera;
    public Transform transformNeedPosCam;
    public GameObject backPositionCam;
    public float turnSpeedCamera = 1f;
    private sfxManager sfxman;
    private float prevSPEED=0;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        sliderSpeedPlayer.maxValue = maxSpeed;
        sliderSpeedPlayer.minValue = 0;
        sliderSpeedPlayer.value = currentSpeed;
        sfxman = FindObjectOfType<sfxManager>();
    }

    // Update is called once per frame
    void CameraMove()
    {
        //if (vspeed != 0)

        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, transformNeedPosCam.position, turnSpeedCamera * Time.deltaTime);
            backPositionCam.transform.position = mainCamera.transform.position;
        }
        //else
        {
           // mainCamera.transform.position = backPositionCam.transform.position;
            //backPositionCam.transform.position = transformNeedPosCam.transform.position;
        }
        mainCamera.transform.rotation = transformNeedPosCam.rotation;
    }

    void SFX()
    {
        if (hspeed != 0 || rspeed!=0)
        {
            if (!sfxman.EngineSide.isPlaying) sfxman.EngineSide.Play();
        }
        else
            sfxman.EngineSide.Stop();
        if (prevSPEED < currentSpeed)
        {
            sfxman.EnginePowerDown.Stop();
            sfxman.EngineIdle.Stop();
            if (!sfxman.EnginePowerUP.isPlaying) sfxman.EnginePowerUP.Play();
        }
        else if (prevSPEED > currentSpeed)
        {
            sfxman.EngineIdle.Stop();
            sfxman.EnginePowerUP.Stop();
            if (!sfxman.EnginePowerDown.isPlaying) sfxman.EnginePowerDown.Play();
        }
        if (prevSPEED == currentSpeed)
            if (!sfxman.EngineIdle.isPlaying)
            {
                sfxman.EngineIdle.Play();
                sfxman.EnginePowerUP.Stop();
                sfxman.EnginePowerDown.Stop();
            }
        prevSPEED = currentSpeed;
    }
    void FixedUpdate()
    {
        rspeed = Input.GetAxis("Vertical");
        transform.Rotate(new Vector3(turnSpeed*rspeed*0.1f,0f,0f)); ;

        hspeed = Input.GetAxis("Horizontal");
        transform.Rotate(new Vector3(0f, 0f, turnSpeed*hspeed*0.2f));

        vspeed = Input.GetAxis("Speed");
        if (currentSpeed < maxSpeed * vspeed)
        {
            currentSpeed = currentSpeed + moveSpeedUP * vspeed*Time.deltaTime;
        }
        else if (vspeed < 0 & currentSpeed > 0)
        {
            currentSpeed = currentSpeed - Time.deltaTime * speedBrakeShip;
        }
        else if (currentSpeed > 0)
        {
            //currentSpeed = currentSpeed - Time.deltaTime * 0.01f;
            if (currentSpeed < 0) currentSpeed = 0;
        }
        Vector3 moveVectorShip;
        moveVectorShip = transform.forward * currentSpeed;
        myRigidBody.velocity = moveVectorShip;
        sliderSpeedPlayer.value = currentSpeed;
        CameraMove();
        SFX();
    }
}
