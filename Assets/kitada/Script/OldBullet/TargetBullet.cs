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
        if (attackTag == "Player")//プレイヤーが使用するとき
        {
            Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//マウスの座標を取得
            Shot(targetPos);
        }
        else//敵が使用するとき
        {
            GameObject player = GameObject.Find("Player");//プレイヤーのゲームオブジェクトを取得
            Vector3 targetPos = player.transform.position;//プレイヤーの位置を取得
            Shot(targetPos);
        }
    }

    private void Shot(Vector3 targetPos)
    {
       
        Vector2 dis = new Vector2(targetPos.x, targetPos.y) - new Vector2(transform.position.x, transform.position.y);//マウスの位置と弾の初期位置間の距離を取得
        float rad = Mathf.Atan2(dis.y, dis.x);//二点間の距離から角度(ラジアン)を求める 
        float sin = Mathf.Sin(rad);//ラジアンからsinを求める
        float cos = Mathf.Cos(rad);//ラジアンからcosを求める
        rb.velocity = new Vector2(cos * speed, sin * speed);//求めたsincosを速度に代入する
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != attackTag && collision.tag != attackTag + "Attack" && !collision.gameObject.CompareTag("Untagged"))//弾を放ったキャラ以外か同じTag以外のオブジェクトに触れたとき
        {
            Destroy(this.gameObject);//このオブジェクトを削除
            
        }
    }
}
