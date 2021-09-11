using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class Playercontrol : MonoBehaviour
{
    float speed = 9;

    
    float walkAcceleration = 75;

    
    float airAcceleration = 30;

    
    float groundDeceleration = 70;

    float jumpHeight = 4;

    private BoxCollider2D boxCollider;

    private Vector2 velocity;

    /// <summary>
    /// Set to true when the character intersects a collider beneath
    /// them in the previous frame.
    /// </summary>
    private bool grounded;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        //boxCollider.size = GetComponent<SpriteRenderer>().sprite.rect.size;
    }

    private void FixedUpdate()
    {
        // Use GetAxisRaw to ensure our input is either 0, 1 or -1.
        float moveInput = Input.GetAxisRaw("Horizontal");
        velocity.y += Physics2D.gravity.y * Time.deltaTime;
        if (grounded)
        {
            velocity.y = 0;

            if (Input.GetButtonDown("Jump"))
            {
                // Calculate the velocity required to achieve the target jump height.
                velocity.y = Mathf.Sqrt(2 * jumpHeight * Mathf.Abs(Physics2D.gravity.y));
            }
        }

        float acceleration = grounded ? walkAcceleration : airAcceleration;
        float deceleration = grounded ? groundDeceleration : 0;

        if (moveInput != 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, speed * moveInput, acceleration * Time.deltaTime);
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
        }

        //    velocity.y += Physics2D.gravity.y * Time.deltaTime;

      //  Debug.Log(velocity.y);
      //  Debug.Log(grounded);

        transform.Translate(velocity * Time.deltaTime);

        grounded = false;

        Vector2 topleft;
        topleft.x = transform.position.x - boxCollider.size.x;
        topleft.y = transform.position.y + boxCollider.size.y;
        Vector2 topright;
        topright.x = transform.position.x + boxCollider.size.x;
        topright.y = transform.position.y + boxCollider.size.y;
        Vector2 botleft;
        botleft.x = transform.position.x - boxCollider.size.x;
        botleft.y = transform.position.y - boxCollider.size.y;
        Vector2 botright;
        botright.x = transform.position.x + boxCollider.size.x;
        botright.y = transform.position.y - boxCollider.size.y;

        Debug.DrawLine(topleft, topright, Color.white, 0.1f);
        Debug.DrawLine(topleft, botleft, Color.white, 0.1f);
        Debug.DrawLine(botleft, botright, Color.white, 0.1f);
        Debug.DrawLine(botright, topright, Color.white, 0.1f);

        Debug.Log(topleft);
        Debug.Log(topright);



        // Retrieve all colliders we have intersected after velocity has been applied.
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, boxCollider.size, 0);

        Debug.Log(hits.Length);

        foreach (Collider2D hit in hits)
        {
            // Ignore our own collider.
            if (hit == boxCollider)
                continue;

            ColliderDistance2D colliderDistance = hit.Distance(boxCollider);
      //      Debug.Log("Collided");

            // Ensure that we are still overlapping this collider.
            // The overlap may no longer exist due to another intersected collider
            // pushing us out of this one.
        //    if (colliderDistance.isOverlapped)
            {
                transform.Translate(colliderDistance.pointA - colliderDistance.pointB);

                // If we intersect an object beneath us, set grounded to true. 
           //     if (Vector2.Angle(colliderDistance.normal, Vector2.up) < 90 && velocity.y < 0)
          //      {
                    grounded = true;
          //      }
            }
        }
    }
}