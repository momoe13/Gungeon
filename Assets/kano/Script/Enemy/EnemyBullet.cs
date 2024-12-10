using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //北田さんのコードを使用。マウスの位置取得の部分をプレイヤーの位置に変更した

    [SerializeField] private float speed;

    Vector2 playerPos;

    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPos = GameObject.Find("Player").transform.position;
        Shot();
    }

    private void Shot()
    {
        Vector2 targetPos = playerPos;
        Vector2 dis = new Vector2(targetPos.x, targetPos.y) - new Vector2(transform.position.x, transform.position.y);//マウスの位置と弾の初期位置間の距離を取得
        float rad = Mathf.Atan2(dis.y, dis.x);//二点間の距離から角度(ラジアン)を求める
        float sin = Mathf.Sin(rad);//ラジアンからsinを求める
        float cos = Mathf.Cos(rad);//ラジアンからcosを求める
        rb.velocity = new Vector2(cos * speed, sin * speed);//求めたsincosを速度に代入する
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.gameObject.CompareTag(Wall))
        //{
        //    Destroy(this.gameObject);//このオブジェクトを削除
        //}

    }
}
