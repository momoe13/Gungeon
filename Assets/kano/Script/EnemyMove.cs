using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    
    NavMeshAgent2D agent;//NavMesh2Dを使用するための変数
    [SerializeField]
    Transform target;//追跡するオブジェクト

    bool searchFlg;

    private void Start()
    {
        //NavMesh2Dの取得
        agent = GetComponent<NavMeshAgent2D>();
    }

    private void Update()
    {
        //agentの目的地を追跡objの座標にする
        agent.SetDestination(target.position);
    
        /*メモ
         * NavMeshAgentスクリプトのほうで移動を行っているので、
         * NavMeshのスクリプトを理解し変更する必要があるかもしれない
         */
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        searchFlg = true;
    }

}
