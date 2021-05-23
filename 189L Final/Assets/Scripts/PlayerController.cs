using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Command;

public class PlayerController : MonoBehaviour
{

    private IPlayerCommand Right;
    private IPlayerCommand Left;
    private IPlayerCommand Up;

    // Start is called before the first frame update
    void Start()
    {
        this.Right = ScriptableObject.CreateInstance<MovePlayerRight>();
        this.Left = ScriptableObject.CreateInstance<MovePlayerLeft>();

        this.gameObject.AddComponent<MovePlayerUp>();
        this.Up = this.gameObject.GetComponent<MovePlayerUp>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0.01)
        {
            this.Right.Execute(this.gameObject);
        }
        if (Input.GetAxis("Horizontal") < -0.01)
        {
            this.Left.Execute(this.gameObject);
        }

        // Needed to change jump inputs to specific keys
        // Using vertical > 0.01 lead to updates that were too fast
        if (Input.GetKeyDown("w") || Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.Up.Execute(this.gameObject);
        }
        //if (Input.GetButtonDown("Jump"))
        //{
        //    this.Up.Execute(this.gameObject);
        //}

        //if (Input.GetKeyDown("space"))
        //{
        //    this.Up.Execute(this.gameObject);
        //}

        // Get the animator for the player. 
        var animator = this.gameObject.GetComponent<Animator>();

        // Set params for animator. 
        animator.SetFloat("X-Velocity", Mathf.Abs(this.gameObject.GetComponent<Rigidbody2D>().velocity.x));
        animator.SetFloat("Y-Velocity", Mathf.Abs(this.gameObject.GetComponent<Rigidbody2D>().velocity.y));
        animator.SetBool("IsGrounded", this.gameObject.GetComponent<MovePlayerUp>().IsGrounded);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Update IsGrounded whenever ground is touched
        if (collision.gameObject.tag == "Ground")
        {
            this.gameObject.GetComponent<MovePlayerUp>().IsGrounded = true;
            //Debug.Log("Works1");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Update Is Grounded whenever player leaves the ground
        if (collision.gameObject.tag == "Ground")
        {
            this.gameObject.GetComponent<MovePlayerUp>().IsGrounded = false;
            //Debug.Log("Works2");
        }
    }

}
