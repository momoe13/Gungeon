using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleSceneManager : MonoBehaviour
{
    //次のシーンの名前
    [SerializeField] private string nextScene;
    //次のシーン番号
    [SerializeField] private int nextSceneIdx;

    [SerializeField] private Text startMsg;

    //点滅時間
    [SerializeField] private float blinkDuration;
    private float nowTime;

    // フェード用のイメージ
    [SerializeField] private Image fadeImg;

    [SerializeField] private float fadeDuration;

    private void Start()
    {
        StartCoroutine(BlinkText());
    }

    private void Update()
    {       
        // Enterキーでスタート
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // フェードアウトした後にシーン移動
            StartCoroutine(FadeOutAndGoNextScene());

        }
    }

    private IEnumerator FadeOutAndGoNextScene()
    {
        //フェードアウト
        while (fadeImg.color.a < 1)
        {
            var tmpcolor = fadeImg.color;
            tmpcolor.a += (1 / fadeDuration) * Time.deltaTime;
            fadeImg.color = tmpcolor;
            yield return null;
        }
        //LoadScene
        SceneManager.LoadScene(nextSceneIdx);
    }

    private IEnumerator BlinkText()
    {
        while (true)
        {
            // blinkDurationごとに状態が変わる
            yield return new WaitForSeconds(blinkDuration);
            startMsg.enabled = !startMsg.enabled;
        }
    }

    //private void UpdateBlinkText()
    //{
    //    if (blinkDuration > nowTime)
    //    {
    //        nowTime += Time.deltaTime;
    //    }
    //    else
    //    {
    //        nowTime = 0;
    //        startMsg.enabled = !startMsg.enabled;

    //        /* bool flag = startMsg.enabled;
    //         if (flag) { startMsg.enabled = false; }
    //         else { startMsg.enabled = true; }*/
    //    }
    //}
}
