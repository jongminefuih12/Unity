using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieSpawner : MonoBehaviour
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

            _enemy.transform.position = new Vector3(Random.Range(-126f, -140f), -13.5f, Random.Range(101f, 12f));

            _enemy.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
            _enemy.AddComponent<NavMeshAgent>();
            // _enemy.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));


            _enemy.name = "zombies";
            yield return new WaitForSeconds(16);
        }
    }
}
