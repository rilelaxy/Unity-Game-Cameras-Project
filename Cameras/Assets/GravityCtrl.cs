using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCtrl : MonoBehaviour
{
    public GravityOrbit Gravity;
    private Rigidbody Rb;

    public float RotationSpeed = 20f;
    public float MoveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleGravity();
        HandleMovement();
    }

    void HandleGravity()
    {
        if (Gravity)
        {
            Vector3 gravityUp = (transform.position - Gravity.transform.position).normalized;
            Vector3 localUp = transform.up;
            Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * transform.rotation;
            transform.up = Vector3.Lerp(transform.up, gravityUp, RotationSpeed * Time.deltaTime);
            Rb.AddForce((-gravityUp * Gravity.Gravity) * Rb.mass);
        }
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveInput = new Vector3(horizontal, 0, vertical);
        Vector3 projectedMove = Vector3.ProjectOnPlane(moveInput, transform.up);

        // Move along the tangent plane
        transform.Translate(projectedMove * MoveSpeed * Time.deltaTime, Space.World);

        // Rotate to match the curvature of the planet
        Quaternion toRotation = Quaternion.FromToRotation(transform.up, -Gravity.transform.up) * transform.rotation;
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, RotationSpeed * Time.deltaTime);
    }
}