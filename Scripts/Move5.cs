using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Move5 : MonoBehaviour
{
    float ForwardSpeed = 6f;
    float BackwardSpeed = 5f;
    private bool Walk = false;
    private bool isGrounded = false;
    Vector3 target;
    float rotateSpeed = 0.15f;
    bool Open = false;
    private bool jumped = false;
    int hp = MaxHp;
    const int MaxHp = 300;
    public AudioClip swordClip;
    public AudioClip doorClip;
    private AudioSource swordAudioSource;
    private AudioSource doorAudioSource;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();


        GameObject swordAudioObject = new GameObject("SwordAudioSource");
        swordAudioObject.transform.parent = transform;
        swordAudioSource = swordAudioObject.AddComponent<AudioSource>();
        swordAudioSource.clip = swordClip;


        GameObject doorAudioObject = new GameObject("DoorAudioSource");
        doorAudioObject.transform.parent = transform;
        doorAudioSource = doorAudioObject.AddComponent<AudioSource>();
        doorAudioSource.clip = doorClip;
    }



    void PlaySwordSound()
    {
        swordAudioSource.Play();
    }

    void PlayDoorSound()
    {
        doorAudioSource.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.name == "ClearDoor")
        {
            Open = true;
            PlayDoorSound();
            Walk = false;
            rotateSpeed = 0f;
            ForwardSpeed = 0;
            BackwardSpeed = 0;
        }
    }

    

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
        jumped = false;
    }

    private void Die()
    {
        animator.SetTrigger("Die");
    }

    public void Damage(int val)
    {
        this.hp -= val;

        this.transform.GetChild(18).GetChild(0).GetComponent<Scrollbar>().size = ((float)this.hp / MaxHp);

        if (hp <= 0)
        {
            SceneManager.LoadScene("DeadScene5");
        }
    }

    public void Heal(int val)
    {
        this.hp += val;

        this.transform.GetChild(18).GetChild(0).GetComponent<Scrollbar>().size = ((float)this.hp / MaxHp);
    }

    private void cameraTransition()
    {

        target = this.transform.position + -this.transform.forward * 4 + this.transform.up * 3;

        Camera.main.transform.forward = this.transform.position - Camera.main.transform.position;

        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, target, 0.05f);

    }



    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlaySwordSound();
            animator.SetTrigger("isAttack");
        }
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
        SceneManager.LoadScene("DeadScene5");
    }

    void Update()
    {
        Attack();
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