using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    public float mSpeed = 10f;
    public CharacterController pController;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    private Vector3 moveDirection = Vector3.zero;

    [Header("Camera")]
    public float minY = -60f;
    public float maxY = 60f;

    void Awake()
    {
        pController = GetComponent<CharacterController>();

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"),
                //Obtains characters x coordinates. Upon character input, updates character coords on x axis
                0, Input.GetAxis("Vertical"));//Does not affect Y axis, character stays grounded
            moveDirection = transform.TransformDirection(moveDirection * mSpeed);
            //Moves Character on x axis
        }
        //if (pRigid.velocity.y < 0)
        //{
        //    pRigid.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        //}
        //else if (pRigid.velocity.y > 0 && !Input.GetButton("Jump"))
        //{
        //    pRigid.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Jump();
        //}
    }
    void Jump()
    {

    }
}
