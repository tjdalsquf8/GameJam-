using System.Collections;
using System.Collections.Generic;
using System.Security;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementCharacterController : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed;
    private Vector3 moveForce;

    private float gravity = -9.8f;
    private float verticalSpeed = 0;
    private float jumpPower = 17.0f;
    public CharacterController Ch_controller;
    private void Awake()
    {
        Ch_controller = GetComponent<CharacterController>();
    }



    // Update is called once per frame
    void Update()
    {
        if (Ch_controller.isGrounded)
        {
            verticalSpeed = 0;
        }
        else
        {
            verticalSpeed += gravity * Time.deltaTime;
        }
        moveForce.y += (verticalSpeed * 0.14f);
        Ch_controller.Move(moveForce * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        direction = transform.rotation * new Vector3(direction.x, 0, direction.z);
        moveForce = new Vector3(direction.x * moveSpeed, moveForce.y, direction.z * moveSpeed);
    }
    public void Jump()
    {
        if (Ch_controller.isGrounded)
        {
            moveForce.y = jumpPower;
        }
    }
}
