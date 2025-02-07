//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;
//using UnityEngine.SceneManagement;
//using UnityEngine.UI;
//using static UnityEditor.PlayerSettings;

//public class zombieking : MonoBehaviour
//{
//    Vector3 pos;
//    string state;
//    Vector3 dir;
//    int hp = MaxHp;
//    const int MaxHp = 250;
//    private Animator animator;


//    public AudioClip zombiesound;
//    private AudioSource audioSource;

//    void Start()
//    {

//        audioSource = GetComponent<AudioSource>();
//        audioSource.clip = zombiesound;
//        this.pos = this.transform.position;
//        this.dir = this.transform.forward;
//        StartCoroutine(ZombieAttack());
//        StartCoroutine(ChangeForward());
//        animator = GetComponent<Animator>();
//    }

//    void PlayZombieSound()
//    {
//        audioSource.Play();
//    }

//    void Die()
//    {
//        SceneManager.LoadScene("Ending");
//        Destroy(gameObject);
//    }

//    public void Damage(int val)
//    {
//        this.hp -= val;

//        this.transform.GetChild(0).GetChild(0).GetComponent<Scrollbar>().size = ((float)this.hp / MaxHp);

//        if (hp <= 0 || transform.position.y < -15)
//        {
//            Die();
//        }
//    }

//    void Update()
//    {
//        Vector3 pos = GameObject.Find("Man").transform.position;

//        float dist = Vector3.Distance(pos, this.transform.position);

//        if (dist < 8.5 && dist > 1.49) //chase
//        {


//            state = "Chase";
//            Vector3 v = pos - this.transform.position;

//            v = Vector3.ProjectOnPlane(v, Vector3.up);

//            this.transform.forward = Vector3.Lerp(this.transform.forward, v.normalized, 0.1f);

//            this.transform.position += this.transform.forward * Time.deltaTime * 3;

//            // this.GetComponent<NavMeshAgent>().SetDestination(pos);
//            animator.SetBool("isRun", true);
//        }
//        else
//        {
//            animator.SetBool("isRun", false);

//        }

//        if (transform.position.y < -15f)
//        {
//            Die();
//        }

//        if (dist < 1.5) 
//        {
//            state = "ZombieAttack";

//            Vector3 dir = this.transform.position - pos;
//            dir = Quaternion.AngleAxis(Random.Range(0f, 365f), Vector3.up) * dir;
//        }



//        if (dist <= 20 && dist >= 8.51) //idle  
//        {

//            this.transform.forward = Vector3.Lerp(this.transform.forward, this.dir, 0.1f);

//            this.transform.position += this.transform.forward * Time.deltaTime * 3;

//            state = "idle";
//            animator.SetBool("isIdle", true);
//            Vector3 dir = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
//        }
//        else
//        {
//            animator.SetBool("isIdle", false);

//        }
//    }

//    IEnumerator ChangeForward()
//    {
//        while (true)
//        {
//            if (state == "idle")
//            {
//                this.dir = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
//            }
//            {
//                yield return new WaitForSeconds(Random.Range(1f, 3f));
//            }
//        }
//    }

//    IEnumerator ZombieAttack()
//    {

//        while (true)
//        {
//            if (state == "ZombieAttack")
//            {
//                PlayZombieSound();
//                animator.SetTrigger("isAttack");
//            }
//            yield return new WaitForSeconds(Random.Range(0.5f, 3.0f));
//        }
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class zombieking : MonoBehaviour
{
    Vector3 pos;
    string state;
    Vector3 dir;
    int hp = MaxHp;
    const int MaxHp = 250;
    private Animator animator;

    public AudioClip zombiesound;
    private AudioSource audioSource;

    private float maxChaseDistance = 20.0f; // 좀비의 최대 추적 거리

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = zombiesound;
        this.pos = this.transform.position;
        this.dir = this.transform.forward;
        StartCoroutine(ZombieAttack());
        StartCoroutine(ChangeForward());
        animator = GetComponent<Animator>();
    }

    void PlayZombieSound()
    {
        audioSource.Play();
    }

    void Die()
    {
        SceneManager.LoadScene("Ending");
        Destroy(gameObject);
    }

    public void Damage(int val)
    {
        this.hp -= val;

        this.transform.GetChild(0).GetChild(0).GetComponent<Scrollbar>().size = ((float)this.hp / MaxHp);

        if (hp <= 0 || transform.position.y < -15)
        {
            Die();
        }
    }

    void Update()
    {
        Vector3 playerPos = GameObject.Find("Man").transform.position;

        float dist = Vector3.Distance(playerPos, this.transform.position);

        if (dist < maxChaseDistance && dist > 1.49f) // 추적
        {
            state = "Chase";
            Vector3 v = playerPos - this.transform.position;

            v = Vector3.ProjectOnPlane(v, Vector3.up);

            this.transform.forward = Vector3.Lerp(this.transform.forward, v.normalized, 0.1f);

            this.transform.position += this.transform.forward * Time.deltaTime * 3;

            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }

        if (transform.position.y < -15f)
        {
            Die();
        }

        if (dist < 1.5f) // 공격
        {
            state = "ZombieAttack";

            Vector3 dir = this.transform.position - playerPos;
            dir = Quaternion.AngleAxis(Random.Range(0f, 365f), Vector3.up) * dir;
        }

        if (dist <= 20 && dist >= maxChaseDistance) // idle
        {
            this.transform.forward = Vector3.Lerp(this.transform.forward, this.dir, 0.1f);

            this.transform.position += this.transform.forward * Time.deltaTime * 3;

            state = "idle";
            animator.SetBool("isIdle", true);
            Vector3 dir = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
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
            yield return new WaitForSeconds(Random.Range(1f, 3f));
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