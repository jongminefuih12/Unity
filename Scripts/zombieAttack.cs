using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieAttack : MonoBehaviour
{
    int power = 9;
    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.gameObject.name == "Man")
        {
            other.gameObject.GetComponent<Move3>().Damage(power);
        }
    }
}
