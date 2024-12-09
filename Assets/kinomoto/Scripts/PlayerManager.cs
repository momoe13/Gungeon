using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField]
    public float HP;      //HPの変数

    private Rigidbody2D rb;
    private float horizontal;
    private float vertical;

    private void Awake()
    {
        //リジッドボディの取得
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        Vector2 newVelocity = new Vector2(horizontal, vertical) * speed;
        rb.velocity = newVelocity;
    }

    private void HandleInput()
    {
        //方向チェックがメイン　= Rawを使う
        //慣性なしの移動
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("EnemyBullet") )
        {
            Debug.Log("当たった");
            HP -= 1;
        }
    }

    public float GetHp()
    {
        return HP;
    }
}
