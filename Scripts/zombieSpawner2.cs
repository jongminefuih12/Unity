using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class zombieSpawner2 : MonoBehaviour
{
    public GameObject Zombie;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    
    // Update is called once per frame
    IEnumerator Spawner()
    {
        while (true)
        {
            GameObject _enemy = GameObject.Instantiate(Zombie);
            zombie2 em = _enemy.AddComponent<zombie2>();

            _enemy.transform.position = new Vector3(Random.Range(-7f, 7f), 0.5f, Random.Range(26f, 45f));

            _enemy.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
            _enemy.AddComponent<NavMeshAgent>();
            // _enemy.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));


            _enemy.name = "zombies";
            yield return new WaitForSeconds(60);
        }
    }
}
