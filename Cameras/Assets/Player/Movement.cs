using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 4f;
    public float rotSpeed = 90f;
    public float gravity = 8f;
    public float jumpForce = 10f;

    private void Update()
    {
        // Rotate the UFO based on arrow keys
        RotateUFO();

        // Move the UFO forward
        MoveUFO();

        // Check for jump input
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void RotateUFO()
    {
        float horizontalInput = Input.GetAxis("Horizontal2");
        transform.Rotate(0f, horizontalInput * rotSpeed * Time.deltaTime, 0f);
    }

    private void MoveUFO()
    {
        float verticalInput = Input.GetAxis("Vertical2");

        // Move the UFO forward
        Vector3 moveDirection = transform.forward * verticalInput * speed;

        // Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the UFO
        transform.Translate(moveDirection * Time.deltaTime, Space.World);
    }

    private void Jump()
    {
        // Apply a vertical force for jumping
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
