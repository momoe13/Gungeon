using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    //次のシーン文字列
    [SerializeField] private string nextScene;
    //次のシーンインデックス
    [SerializeField] private int nextSceneIdx;
    //Updateでキーが入力されたらゲームシーンに移動
    private void Update()
    {
        // Enterキーでスタート
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //　インデックスで呼ぶ
            SceneManager.LoadScene(nextSceneIdx);
        }
    }
}
