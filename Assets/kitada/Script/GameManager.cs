using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject[] enemys;//敵を格納する配列
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
        //タイマーの処理
        //スタートのフラグがたったらタイマースタート
        if (!isStart) return;
        timer += Time.deltaTime;
    }

    private void EnemyManager()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");//Enemyのタグを持つオブジェクトを格納
        if(enemys.Length == 0)
        {
            //ゲームクリア
        }
    }
}
