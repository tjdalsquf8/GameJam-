using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // UI 관련 클래스 추가

public class SceneChange : MonoBehaviour
{
    public Image panel; // 페이드 효과를 위한 패널
    private float time = 0f;
    private float fadeDuration = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // 플레이어가 트리거에 닿으면 페이드 아웃 시작
            StartCoroutine(FadeAndLoadScene("EndScene"));
        }
    }

    IEnumerator FadeAndLoadScene(string sceneName)
    {
        // 패널을 활성화하고 페이드 아웃 시작
        panel.gameObject.SetActive(true);
        Color alpha = panel.color;
        alpha.a = 0;
        panel.color = alpha;

        while (alpha.a < 1f)
        {
            time += Time.deltaTime / fadeDuration;
            alpha.a = Mathf.Lerp(0, 1, time);
            panel.color = alpha;
            yield return null;
        }

        // 페이드 아웃이 완료된 후 씬 전환
        SceneManager.LoadScene("EndScene");
    }
}
