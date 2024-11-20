using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBullet : MonoBehaviour
{
    [SerializeField] private float speed;//弾の速度
    [SerializeField] private string attackTag;//弾のTag

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Shot();
    }

    private void Shot()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//マウスの座標を取得
        Vector2 dis = new Vector2(mousePos.x, mousePos.y) - new Vector2(transform.position.x, transform.position.y);//マウスの位置と弾の初期位置間の距離を取得
        float rad = Mathf.Atan2(dis.y, dis.x);//二点間の距離から角度(ラジアン)を求める 
        float sin = Mathf.Sin(rad);//ラジアンからsinを求める
        float cos = Mathf.Cos(rad);//ラジアンからcosを求める
        rb.velocity = new Vector2(cos * speed, sin * speed);//求めたsincosを速度に代入する
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != attackTag && collision.tag != attackTag + "Attack")//弾を放ったキャラ以外か同じTag以外のオブジェクトに触れたとき
        {
            Destroy(this.gameObject);//このオブジェクトを削除
            
        }
    }
}
