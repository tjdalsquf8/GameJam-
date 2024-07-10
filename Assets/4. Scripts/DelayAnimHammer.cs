using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayAnimHammer : MonoBehaviour
{
    public Animator anim;
    public float minDelay = 1.0f;  // 최소 딜레이 시간
    public float maxDelay = 3.0f;  // 최대 딜레이 시간

    private void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(AnimationChange1());
    }

    IEnumerator AnimationChange1()
    {
        while (true)
        {
            // 랜덤 딜레이 시간 설정
            float delaySeconds1 = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delaySeconds1);

            anim.SetBool("isWorking", true);
            // 확실하게 Digging 상태로 진입을 기다립니다.
            yield return new WaitUntil(() => anim.GetCurrentAnimatorStateInfo(0).IsName("isWorking"));
            // Digging 애니메이션이 끝날 때까지 기다립니다.
            yield return new WaitUntil(() => anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f);
            anim.SetBool("isWorking", false);
        }
    }
}

