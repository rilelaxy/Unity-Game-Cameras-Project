using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public bool destroyCollectibles;
    public float pushPower = 2.0f;

    void OnCollisionEnter(Collision collision)
    {
        HandleCollision(collision.collider);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        HandleCollision(hit.collider);
    }

    void HandleCollision(Collider collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            // Destroy the game object this script is attached to (the bullet prefab)
            Destroy(gameObject);
        }
        else if (collider.gameObject.tag == "Player2")
        {
            // Modify Player2Health using the Movement2 script
            Movement2 movement2 = collider.gameObject.GetComponent<Movement2>();

            if (movement2 != null)
            {
                // Set Player2Health to -1 or any other desired value
                movement2.Player2Health -= 1;
                Destroy(gameObject);
            }
        }
        else if (destroyCollectibles && collider.gameObject.tag == "Collectible")
        {
            // Destroy the collided object (Collectible)
            Destroy(collider.gameObject);
        }

        // Add additional logic here if needed
    }
}
