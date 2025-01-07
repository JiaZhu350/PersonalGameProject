using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 playerVelocity;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private RigidbodyConstraints2D rbConstraints;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float playerMovementSpeed = 5f;
    [SerializeField] private float jumpForce = 10;

    private float speedModifier = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        if (DialogueManager.GetInstance().playingDialogue)
        {
            return;
        }
        playerSprint();
        movementController();
        flipPlayer();
    }
    
    void Update()
    {
        if (DialogueManager.GetInstance().playingDialogue)
        {
            return;
        }

        playerJump();
    }

    private void movementController()
    {
        playerVelocity.x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(playerVelocity.x * playerMovementSpeed * speedModifier, rb.velocity.y);
    }

    private void flipPlayer()
    {
        if (playerVelocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (playerVelocity.x > 0) 
        {
            spriteRenderer.flipX = false;
        }
    }
    
    private void playerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    private void playerSprint()
    {
        if (Input.GetKey("left shift")) // sprinting
        {
            speedModifier = 1.5f;
        }
        else
        {
            speedModifier = 1f;
        }
    }
}
