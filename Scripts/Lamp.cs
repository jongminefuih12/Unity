using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public GameObject Image;
    public GameObject Light;

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.gameObject.name == "Man")
        {
            Image.SetActive(false);
            Light.SetActive(true);
        }
    }
   
}
