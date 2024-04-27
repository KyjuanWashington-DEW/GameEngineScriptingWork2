using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 10f; 
    private Animator animator;
    public int health = 100;
    public int trapdamage = 100;
    public bool mariohb = true;
    public bool trapdb = true;
    

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trap") && mariohb && trapdb)
        {
            TrapDamage();
        }
    }
    private void TrapDamage()
    {
        health -= trapdamage;
    }
    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
       
        if (health <= 0)
        {
            animator.SetBool("IsDead", true);
            
        }
    
       else if (horizontalInput != 0)
        {
        
            animator.SetBool("IsWalking", true);
            transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);

          
            bool isFacingRight = horizontalInput > 0;
            animator.SetBool("IsFacingRight", isFacingRight);
        }
        else
        {
           
            animator.SetBool("IsWalking", false);
        }

        // Jumping logic
        if (verticalInput > 0)
        {
            // Jumping up
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsJumpingLeft", false);
            animator.SetBool("IsJumpingRight", false);
        }
        else if (horizontalInput < 0)
        {
            // Jumping left
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsJumpingLeft", true);
            animator.SetBool("IsJumpingRight", false);
        }
        else if (horizontalInput > 0)
        {
            // Jumping right
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsJumpingLeft", false);
            animator.SetBool("IsJumpingRight", true);
        }
        else
        {
            // Not jumping
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsJumpingLeft", false);
            animator.SetBool("IsJumpingRight", false);
        }
    }
}





