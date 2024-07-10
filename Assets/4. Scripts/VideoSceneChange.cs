using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // UI ���� Ŭ���� �߰�
using UnityEngine.Video;

public class VideoSceneChange : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName = "NextScene";
    public Image panel; // ���̵� ȿ���� ���� �г�
    private float time = 0f;
    private float fadeDuration = 3.0f;

    void Start()
    {
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        StartCoroutine(FadeAndLoadScene());
    }

    IEnumerator FadeAndLoadScene()
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
        SceneManager.LoadScene(nextSceneName);
    }
}
