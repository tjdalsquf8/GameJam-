using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayAnimHammer : MonoBehaviour
{
    public Animator anim;
    public float minDelay = 1.0f;  // �ּ� ������ �ð�
    public float maxDelay = 3.0f;  // �ִ� ������ �ð�

    private void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(AnimationChange1());
    }

    IEnumerator AnimationChange1()
    {
        while (true)
        {
            // ���� ������ �ð� ����
            float delaySeconds1 = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delaySeconds1);

            anim.SetBool("isWorking", true);
            // Ȯ���ϰ� Digging ���·� ������ ��ٸ��ϴ�.
            yield return new WaitUntil(() => anim.GetCurrentAnimatorStateInfo(0).IsName("isWorking"));
            // Digging �ִϸ��̼��� ���� ������ ��ٸ��ϴ�.
            yield return new WaitUntil(() => anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f);
            anim.SetBool("isWorking", false);
        }
    }
}

