using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ufoDamage : MonoBehaviour
{
    GameObject prop;
    string target = "Prop";
   void Start()
    {
        prop = GameObject.Find("Prop");
    }
    private void Update()
    {
        Vector3 pos1 = GameObject.Find(target).transform.position;
        Vector3 pos2 = this.transform.position;

        Vector3 v = pos1 - pos2;

        this.transform.position = this.transform.position + v.normalized * 0.005f;

        if (v.magnitude < 0.2f)
        {
            target = "Prop";
        }
    }
}
