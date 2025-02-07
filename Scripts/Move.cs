using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class Move : MonoBehaviour
{
    float ForwardSpeed = 6f;
    float BackwardSpeed = 5f;
    private bool Walk = false;
    private bool isGrounded = false;
    private bool jumped = false;
    Vector3 target;
    float rotateSpeed = 0.15f;   
    bool Open = false;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            jumped = false;
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.name == "ClearDoor")
        {
            Open = true;
            GetComponent<AudioSource>().Play();
            Walk = false;
            rotateSpeed = 0f;
            ForwardSpeed = 0;
            BackwardSpeed = 0;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    private void Die()
    {
        animator.SetTrigger("Die");
    }


private void cameraTransition()
    {
        
            target = this.transform.position + -this.transform.forward * 4 + this.transform.up * 3;

            Camera.main.transform.forward = this.transform.position - Camera.main.transform.position;
        
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, target, 0.05f);
    }


    void playerMovement()
    {
       
        Walk = false;

        if (!Open)
        {
            if (Input.GetKey(KeyCode.W))
            {
                this.transform.position += this.transform.forward * ForwardSpeed * Time.deltaTime;
                Walk = true;
            }


            if (Input.GetKey(KeyCode.S))
            {
                this.transform.position -= this.transform.forward * BackwardSpeed * Time.deltaTime;
                Walk = true;
            }

            if (Input.GetKey(KeyCode.D))
            {
                this.transform.rotation = Quaternion.AngleAxis(rotateSpeed, this.transform.up) * this.transform.rotation;
            }
            if (Input.GetKey(KeyCode.A))
            {
                this.transform.rotation = Quaternion.AngleAxis(-rotateSpeed, this.transform.up) * this.transform.rotation;
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                this.GetComponent<Rigidbody>().AddForce(this.transform.up * 5f, ForceMode.Impulse);
                animator.SetTrigger("IsJump");
                jumped = true;
            }
        }
    }

    public void DeadScene()
    {
        SceneManager.LoadScene("DeadScene");
    }

    void Update()
    {
        playerMovement();
        cameraTransition();

        animator.SetBool("Open", Open);
        animator.SetBool("Grounded", isGrounded);
        animator.SetBool("Walk", Walk);

        if (transform.position.y < -15f)
        {
            Die();
            Invoke("DeadScene", 3.0f);
            rotateSpeed = 0f;
            ForwardSpeed = 0;
            BackwardSpeed = 0;
        }
    }
}