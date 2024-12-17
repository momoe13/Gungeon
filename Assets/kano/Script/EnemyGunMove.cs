using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMove : MonoBehaviour
{
    [SerializeField]
    Transform player;   //プレイヤーの位置

    [SerializeField]
    Transform enemy;    //親オブジェクトの位置

    [SerializeField]
    private float radius;//円形に移動範囲に制限をかける円の半径

    private void Awake()
    {
        //親オブジェクトの位置を取得
        enemy = this.gameObject.transform.parent.gameObject.transform;
    }

    private void Update()
    {
        float distance = Vector3.Distance(player.transform.position, enemy.transform.position);

        if (distance > radius)
        {
            Vector3 GunPos = (player.transform.position - enemy.transform.position).normalized;

            //移動させる
            this.transform.localPosition = GunPos * radius;

        }
    }
}
