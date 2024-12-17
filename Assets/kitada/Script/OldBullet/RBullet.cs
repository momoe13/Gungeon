using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBullet : MonoBehaviour
{
    [HideInInspector] public float deg = 0;
    [HideInInspector] public float speed = 1;
    [HideInInspector] public string aTag;

    private Rigidbody2D rb;

    public void Shot()
    {
        rb = GetComponent<Rigidbody2D>();
        float rad = deg * Mathf.Deg2Rad;//角度からラジアンを求める
        float sin = Mathf.Sin(rad);//ラジアンからsinを求める
        float cos = Mathf.Cos(rad);//ラジアンからcosを求める
        rb.velocity = new Vector2(cos * speed, sin * speed);//求めたsincosを速度に代入する
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != aTag && collision.tag != aTag + "Attack")//弾を放ったキャラ以外か同じTag以外のオブジェクトに触れたとき
        {
            Destroy(this.gameObject);//このオブジェクトを削除
        }
    }
}
