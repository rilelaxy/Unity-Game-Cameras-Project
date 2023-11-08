using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPro : MonoBehaviour
{
    public GameObject projectile;
    public float launchVelocity = 700f;
    Vector3 launcher;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Launch();
        }
    }

    void Launch()
    {
        GameObject ball = Instantiate(projectile, transform.position, transform.rotation);
        ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity, 0));
    }

    void OnCollisionEnter(Collision collision)
    {
  
        if (collision.gameObject.CompareTag("Player2")) {
            Destroy(gameObject); 
        }
    }
}
