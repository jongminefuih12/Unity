using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class zombie2 : MonoBehaviour
{
    Vector3 pos;
    string state;
    Vector3 dir;
    int hp = MaxHp;
    const int MaxHp = 30;
    private Animator animator;

    static int killedZombies = 0;
    

    public AudioClip zombiesound;
    private AudioSource zombieAudioSource;

    void Start()
    {
        zombieAudioSource = GetComponent<AudioSource>();
        zombieAudioSource.clip = zombiesound;
        this.pos = this.transform.position;
        this.dir = this.transform.forward;
        StartCoroutine(ZombieAttack());
        StartCoroutine(ChangeForward());
        animator = GetComponent<Animator>();
    }

    

    void PlayZombieSound()
    {
        zombieAudioSource.Play();
    }

    void Die()
    {
        killedZombies++;

        if (killedZombies >= 5)
        {
            SceneManager.LoadScene("Final2");

        }
        Destroy(gameObject);
    }

    public void Damage(int val)
    {
        this.hp -= val;

        this.transform.GetChild(0).GetChild(0).GetComponent<Scrollbar>().size = ((float)this.hp / MaxHp);

        if (hp <= 0)
        {
            Die();
        }
    }

    void Update()
    {


        Vector3 pos = GameObject.Find("Man").transform.position;

        float dist = Vector3.Distance(pos, this.transform.position);

        

        if (dist < 8.5 && dist > 1.49) //chase
        {


            state = "Chase";
            Vector3 v = pos - this.transform.position;

            v = Vector3.ProjectOnPlane(v, Vector3.up);

            this.transform.forward = Vector3.Lerp(this.transform.forward, v.normalized, 0.1f);

            this.transform.position += this.transform.forward * Time.deltaTime * 3;

            // this.GetComponent<NavMeshAgent>().SetDestination(pos);
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);

        }

        
        //if (transform.position.y < -15f)
        //{
        //    Die();
        //}

        if (dist < 1.5) //attack    
        {
            state = "ZombieAttack";

            Vector3 dir = this.transform.position - pos;
            dir = Quaternion.AngleAxis(Random.Range(0f, 365f), Vector3.up) * dir;
            //  this.GetComponent<NavMeshAgent>().SetDestination(pos + dir);
        }



        if (dist <= 20 && dist >= 8.51) //idle  
        {
            // this.GetComponent<NavMeshAgent>().destination = new Vector3(Random.Range(-15f, 15f), 1, Random.Range(-15f, 15f));

            this.transform.forward = Vector3.Lerp(this.transform.forward, this.dir, 0.1f);

            this.transform.position += this.transform.forward * Time.deltaTime * 3;



            state = "idle";
            animator.SetBool("isIdle", true);
            Vector3 dir = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            //  this.GetComponent<NavMeshAgent>().SetDestination(this.transform.position + dir.normalized * 3);
        }
        else
        {
            animator.SetBool("isIdle", false);

        }



    }

    IEnumerator ChangeForward()
    {
        while (true)
        {
            if (state == "idle")
            {
                this.dir = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
            }
            {
                yield return new WaitForSeconds(Random.Range(1f, 3f));
            }
        }
    }

    IEnumerator ZombieAttack()
    {

        while (true)
        {
            if (state == "ZombieAttack")
            {
                PlayZombieSound();
                animator.SetTrigger("isAttack");
            }
            yield return new WaitForSeconds(Random.Range(0.5f, 3.0f));
        }
    }

}
