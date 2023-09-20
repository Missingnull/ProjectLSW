using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;

    public Rigidbody2D rb;
    public BoxCollider2D boxCollider2D;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Consume movement input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Interact with shopkeeper
        if (Input.GetButtonDown("Interact"))
        {
            Debug.Log("Interacted");
        }
    }

    private void FixedUpdate()
    {
        // Move the player character
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
