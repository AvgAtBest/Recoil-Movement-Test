using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    public float mSpeed = 10f;
    public Rigidbody pRigid;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public bool rotateToMainCamera = false;
    public bool rotateWeapon = false;
    public Rigidbody rigid;

    private RocketLauncher currentWeapon;
    private Vector3 moveDir;
    private Vector3 moveDirection;

    [Header("Camera")]

    public Camera pCamera;
    public float rotX = 0f;
    public float rotY = -60f;
    public float sensitivity = 10f;

    void Awake()
    {
        pRigid = this.GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        float inputH = Input.GetAxis("Horizontal") * mSpeed;
        float inputV = Input.GetAxis("Vertical") * mSpeed;
        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY = Input.GetAxis("Mouse X") * sensitivity;

        pRigid.velocity = new Vector3(inputH * mSpeed, pRigid.velocity.y, inputV * mSpeed);
        transform.Rotate(0, rotX, 0);
        pCamera.transform.Rotate(rotY, 0, 0);
        pRigid.velocity = transform.rotation * pRigid.velocity;


        // Get the euler angles of Camera
        Vector3 camEuler = Camera.main.transform.eulerAngles;

        // Is the contorller rotating to the camera?
        if (rotateToMainCamera)
        {
            // Calculate the new move direction by only taking into account the Y Axis
            moveDir = Quaternion.AngleAxis(camEuler.y, Vector3.up) * moveDir;
        }

        Vector3 force = new Vector3(moveDir.x, rigid.velocity.y, moveDir.z);

        rigid.velocity = force;

        Quaternion playerRotation = Quaternion.AngleAxis(camEuler.y, Vector3.up);
        transform.rotation = playerRotation;

        if (rotateWeapon)
        {
            Quaternion weaponRotation = Quaternion.AngleAxis(camEuler.x, Vector3.right);
            currentWeapon.transform.localRotation = weaponRotation;
        }


        if (Input.GetKeyDown(KeyCode.W))
        {

        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        //switch (currentState)
        //{
        //    case State.MouseXandY:
        //        MouseXandY();
        //        break;
        //    case State.MouseX:
        //        MouseX();
        //        break;
        //    case State.MouseY:
        //        MouseY();
        //        break;
        //    default:
        //        break;

        //}
    }
    void Jump()
    {
        if (pRigid.velocity.y < 0)
        {
            pRigid.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (pRigid.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            pRigid.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
    //private void MouseXandY()
    //{
    //    //The float for X axis is equal to Y axis + the mouse input on the X axis times our X sensitivity
    //    float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
    //    //Y Rotation is += our mouse Y times Y sensitivity
    //    rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
    //    //Min and Max Y axis limit is clamped using Mathf.
    //    rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
    //    //Transform players local position to the new vector3 rotation. -y rotation on the X axis and X rotation on the Y axis
    //    transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
    //}
    //private void MouseX()
    //{
    //    //transform rotation around Y axis by mouse input. Mouse X times sensitivityX
    //    transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
    //}
    //private void MouseY()
    //{
    //    //Rotation Y is += to mouse input for Mouse Y times Y sensitivity
    //    rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
    //    //Min and Max Y axis limit is clamped using Mathf.
    //    rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
    //    //Transform players local position to the new vector3 rotation. -y rotation on the X axis and X rotation on the Y axis
    //    transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
    //}
}