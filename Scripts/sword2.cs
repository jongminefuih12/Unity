using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword2 : MonoBehaviour
{
    int SwordPower = 10;
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


        if (isSwinging && (other.gameObject.name == "zombies"))
        {
            other.gameObject.GetComponent<zombie2>().Damage(SwordPower);
        }
    }

}
