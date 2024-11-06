using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    
    NavMeshAgent2D agent;//NavMesh2Dを使用するための変数
    [SerializeField]
    Transform target;//追跡するオブジェクト

    
    [SerializeField]
    bool searchFlg = false;//プレイヤーとの距離判定


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
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            searchFlg = true;
        }
    }

}
