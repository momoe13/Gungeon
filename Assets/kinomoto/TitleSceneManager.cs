using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleSceneManager : MonoBehaviour
{
    //���̃V�[���̖��O
    [SerializeField] private string nextScene;
    //���̃V�[���ԍ�
    [SerializeField] private int nextSceneIdx;

    [SerializeField] private Text startMsg;

    //�_�Ŏ���
    [SerializeField] private float blinkDuration;
    private float nowTime;

    // �t�F�[�h�p�̃C���[�W
    [SerializeField] private Image fadeImg;

    [SerializeField] private float fadeDuration;

    private void Start()
    {
        StartCoroutine(BlinkText());
    }

    private void Update()
    {       
        // Enter�L�[�ŃX�^�[�g
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // �t�F�[�h�A�E�g������ɃV�[���ړ�
            StartCoroutine(FadeOutAndGoNextScene());

        }
    }

    private IEnumerator FadeOutAndGoNextScene()
    {
        //�t�F�[�h�A�E�g
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
            // blinkDuration���Ƃɏ�Ԃ��ς��
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
