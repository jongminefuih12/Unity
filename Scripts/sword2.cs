using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword2 : MonoBehaviour
{
    int SwordPower = 10;
    bool isSwinging = false;

    void Update()
    {
        // 마우스 왼쪽 버튼 클릭 시 검을 휘두르도록 설정
        if (Input.GetMouseButtonDown(0))
        {
            isSwinging = true;
            // 애니메이션 또는 휘두르는 동작이 여기에 추가될 수 있음
            StartCoroutine(SwingCooldown());
        }
    }

    IEnumerator SwingCooldown()
    {
        // 휘두르는 동안 일정 시간 동안만 유지
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
