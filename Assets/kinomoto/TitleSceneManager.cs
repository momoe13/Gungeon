using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    //���̃V�[��������
    [SerializeField] private string nextScene;
    //���̃V�[���C���f�b�N�X
    [SerializeField] private int nextSceneIdx;
    //Update�ŃL�[�����͂��ꂽ��Q�[���V�[���Ɉړ�
    private void Update()
    {
        // Enter�L�[�ŃX�^�[�g
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //�@�C���f�b�N�X�ŌĂ�
            SceneManager.LoadScene(nextSceneIdx);
        }
    }
}
