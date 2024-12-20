using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float deg;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float rad = deg * Mathf.Deg2Rad;//角度をラジアンに変換
        //sin,cosを求める
        float sin = Mathf.Sin(rad);
        float cos = Mathf.Cos(rad);
        
        rb.velocity = new Vector2(cos * speed, sin * speed);
    }
}
