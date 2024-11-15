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
    bool searchFlg = false;//プレイヤーとの距離判定

    [SerializeField] 
    private GameObject bullets;//弾

    [SerializeField]
    float attackTime;         //攻撃タイミング
    float timeCount;          //秒数カウント

    [SerializeField]
    int hp;                   //体力


    private void Start()
    {
        //NavMesh2Dの取得
        agent = GetComponent<NavMeshAgent2D>();
    }

    private void Update()
    {
        if(!searchFlg)
        {
            //agentの目的地を追跡objの座標にする
            agent.SetDestination(target.position);
        }
        timeCount += Time.deltaTime;

        if (timeCount > attackTime)
        {
            Attack();
            timeCount = 0;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            searchFlg = true;
        }
        if(collision.gameObject.CompareTag("PlayerBullet"))
        {
            Damage();
        }
    }

    private void Attack()
    {

        Instantiate(bullets, transform.position, Quaternion.identity);
    }

    private void Damage()
    {
        hp--;
        if (hp < 0) 
        { 
           Destroy(this.gameObject);
        }
    }
}
