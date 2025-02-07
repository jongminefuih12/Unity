using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aid : MonoBehaviour
{
    int Heal = 100;
    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.gameObject.name == "Man")
        {
            other.gameObject.GetComponent<Move5>().Heal(Heal);
            Destroy(this.gameObject);
        }
    }
}
