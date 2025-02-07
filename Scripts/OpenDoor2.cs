using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor2 : MonoBehaviour
{
    bool Open = false;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Load()
    {
        SceneManager.LoadScene("ClearScene2");
    }
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.name == "Man")
        {
            Invoke("Opening", 0.4f);
            Invoke("Load", 2.3f);
        }
    }
    void Opening()
    {
        Open = true;
    }
    void Update()
    {

        animator.SetBool("Open", Open);

    }
}
