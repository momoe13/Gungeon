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
        float rad = deg * Mathf.Deg2Rad;//�p�x���烉�W�A�������߂�
        float sin = Mathf.Sin(rad);//���W�A������sin�����߂�
        float cos = Mathf.Cos(rad);//���W�A������cos�����߂�
        rb.velocity = new Vector2(cos * speed, sin * speed);//���߂�sincos�𑬓x�ɑ������
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != aTag && collision.tag != aTag + "Attack")//�e��������L�����ȊO������Tag�ȊO�̃I�u�W�F�N�g�ɐG�ꂽ�Ƃ�
        {
            Destroy(this.gameObject);//���̃I�u�W�F�N�g���폜
        }
    }
}
