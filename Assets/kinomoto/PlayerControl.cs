using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5;
    Rigidbody2D rb;
    private Vector2 move;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //入力の取得
        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        //物理計算
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
    }
}