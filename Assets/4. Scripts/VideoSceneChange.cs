using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // UI 관련 클래스 추가
using UnityEngine.Video;

public class VideoSceneChange : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName = "NextScene";
    public Image panel; // 페이드 효과를 위한 패널
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
        SceneManager.LoadScene(nextSceneName);
    }
}
