using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fall : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.name == "Man")
        {
            rb.isKinematic = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
