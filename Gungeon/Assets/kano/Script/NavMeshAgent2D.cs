using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgent2D : MonoBehaviour
{
    [Header("Steering")]
    public float speed = 1.0f;
    public float stoppingDistance = 0;

    [HideInInspector]//常にUnityエディタから非表示
    private Vector2 trace_area = Vector2.zero;


    //パターン１
    public Vector2 destination
    {
        get { return trace_area; }
        set
        {
            trace_area = value;
            Trace(transform.position, value);
        }
    }


    //パターン２
    public bool SetDestination(Vector2 target)
    {
        destination = target;
        return true;
    }


    /*メモ
     * 他スクリプトからパターン１又は２が呼び出される
     *　　↓
     * パターン１からTraceが呼ばれ、経路を求めて呼び出してきたオブジェクトの位置を変更する
     */

    private void Trace(Vector2 current, Vector2 target)
    {
        if (Vector2.Distance(current, target) <= stoppingDistance)
        {
            return;
        }

        // NavMesh に応じて経路を求める
        NavMeshPath path = new NavMeshPath();
        NavMesh.CalculatePath(current, target, NavMesh.AllAreas, path);

        Vector2 corner = path.corners[0];

        if (Vector2.Distance(current, corner) <= 0.05f)
        {
            corner = path.corners[1];
        }

        transform.position = Vector2.MoveTowards(current, corner, speed * Time.deltaTime);
    }
}