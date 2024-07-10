using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // UI ���� Ŭ���� �߰�

public class SceneChange : MonoBehaviour
{
    public Image panel; // ���̵� ȿ���� ���� �г�
    private float time = 0f;
    private float fadeDuration = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // �÷��̾ Ʈ���ſ� ������ ���̵� �ƿ� ����
            StartCoroutine(FadeAndLoadScene("EndScene"));
        }
    }

    IEnumerator FadeAndLoadScene(string sceneName)
    {
        // �г��� Ȱ��ȭ�ϰ� ���̵� �ƿ� ����
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

        // ���̵� �ƿ��� �Ϸ�� �� �� ��ȯ
        SceneManager.LoadScene("EndScene");
    }
}
