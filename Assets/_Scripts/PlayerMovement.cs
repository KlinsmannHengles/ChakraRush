using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Essential")]  
    [SerializeField] private Rigidbody2D rb;
    private Vector2 movement;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed;

    [Header("Animation")]
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("MoveY", movement.y);

        // it makes the character moves on the same speed in diagonals
        movement = new Vector2(movement.x, movement.y).normalized;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
