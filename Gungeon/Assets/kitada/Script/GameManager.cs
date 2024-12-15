using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject[] enemys;//�G���i�[����z��
    public float timer = 0;
    public bool isStart;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        Timer();
        EnemyManager();
    }

    private void Timer()
    {
        //�^�C�}�[�̏���
        //�X�^�[�g�̃t���O����������^�C�}�[�X�^�[�g
        if (!isStart) return;
        timer += Time.deltaTime;
    }

    private void EnemyManager()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");//Enemy�̃^�O�����I�u�W�F�N�g���i�[
        if(enemys.Length == 0)
        {
            //�Q�[���N���A
        }
    }
}
