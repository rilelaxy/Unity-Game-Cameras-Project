using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPro : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
  
        if (collision.gameObject.CompareTag("Gear")) {
            Destroy(collision.gameObject);
        }
    }
}
