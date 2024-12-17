using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private string attackTag;//弾を使用するオブジェクトのタグを入れる
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void SetVelocity(Vector2 vel)//速度を代入
    { 
        _rb.velocity = vel;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //同じTagの弾か弾を放ったオブジェクト以外に当たった時
        //弾を削除
        if(collision.tag == this.tag) return;
        if(collision.tag == attackTag) return;
        Destroy(this.gameObject);
    }
}
