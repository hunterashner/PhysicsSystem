using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    // Drag & Drop the camera in this field, in the inspector
    public Transform cameraTransform;
    private Vector3 moveDirection = Vector3.zero;
    void Update()
    {
       CharacterController controller = GetComponent<CharacterController>();
       if (controller.isGrounded)
       {
           moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
           moveDirection = cameraTransform.TransformDirection(moveDirection);
           moveDirection *= speed;

           if (Input.GetButton("Jump"))
                    moveDirection.y = jumpSpeed;
       }

         moveDirection.y -= gravity * Time.deltaTime;
         controller.Move(speed * moveDirection * Time.deltaTime);
     }

}
