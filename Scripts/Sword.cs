using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    int SwordPower = 7;
    bool isSwinging = false;

    void Update()
    {
        // ���콺 ���� ��ư Ŭ�� �� ���� �ֵθ����� ����
        if (Input.GetMouseButtonDown(0))
        {
            isSwinging = true;
            // �ִϸ��̼� �Ǵ� �ֵθ��� ������ ���⿡ �߰��� �� ����
            StartCoroutine(SwingCooldown());
        }
    }

    IEnumerator SwingCooldown()
    {
        // �ֵθ��� ���� ���� �ð� ���ȸ� ����
        yield return new WaitForSeconds(0.5f);
        isSwinging = false;
    }

    private void OnTriggerEnter(UnityEngine.Collider other)
    {


        if (isSwinging && (other.gameObject.name == "Zombie" || other.gameObject.name == "Zombie1" || other.gameObject.name == "Zombie2"))
        {
            other.gameObject.GetComponent<zombie>().Damage(SwordPower);
        }
    }
    
}
