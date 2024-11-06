using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBullet : MonoBehaviour
{
    [HideInInspector] public float deg = 0;
    [HideInInspector] public float speed = 1;

    private  bool isAddList = false;
    private Rigidbody2D rb;

    public void Shot()
    {
        rb = GetComponent<Rigidbody2D>();
        float rad = deg * Mathf.Deg2Rad;//�p�x���烉�W�A�������߂�
        float sin = Mathf.Sin(rad);//���W�A������sin�����߂�
        float cos = Mathf.Cos(rad);//���W�A������cos�����߂�
        rb.velocity = new Vector2(cos * speed, sin * speed);//���߂�sincos�𑬓x�ɑ������
    }
}
