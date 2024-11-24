using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    
    NavMeshAgent2D agent;   //NavMesh2Dを使用するための変数
    [SerializeField]
    Transform target;       //追跡するオブジェクト

    
    [SerializeField]
    bool searchFlg = false; //プレイヤーとの距離判定

    [SerializeField] 
    private GameObject bullets;//弾

    private Transform gun; 

    [SerializeField]
    float attackTime;         //攻撃タイミング
    float timeCount;          //秒数カウント

    [SerializeField]
    int attackCount;          //リロードまでのカウント
    
    [SerializeField]
    float reloadTime;         //リロードの秒数
    
    [SerializeField]
    int hp;                   //体力


    private void Start()
    {
        //NavMesh2Dの取得
        agent = GetComponent<NavMeshAgent2D>();


        //弾発射位置の取得
        gun = transform.Find("Gun").transform;

    }

    private void Update()
    {
        if(!searchFlg)
        {
            //agentの目的地を追跡objの座標にする
            agent.SetDestination(target.position);
        }
        timeCount += Time.deltaTime;

        //カウントが攻撃時間を上回ったら攻撃
        if (timeCount > attackTime)
        {
            //攻撃関数呼び出し
            Attack();

            //カウント0に戻す
            timeCount = 0;

            //リロードのカウントダウン
            attackCount--;
        }

        //TODO:リロード処理

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //サーチ範囲にプレイヤーが入ったら停止
        if (collision.gameObject.CompareTag("Player"))
        {
            searchFlg = true;
        }
      
    }

    //敵本体の当たり判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //プレイヤーの弾に当たったらHP減少
        if (collision.gameObject.CompareTag("PlayerAttack"))
        {
            Damage();
        }
    }

    private void Attack()
    {
        //TODO:01 プレイヤーの位置を取得し、プレイヤーに近い位置から弾を生成
        Instantiate(bullets, gun.position, Quaternion.identity);
    }

    //ダメージ判定
    private void Damage()
    {
        hp--;
        //HPが0以下になったらオブジェクト消滅
        if (hp <= 0) 
        { 
           Destroy(this.gameObject);
        }
    }
}


