using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //�k�c����̃R�[�h���g�p�B�}�E�X�̈ʒu�擾�̕������v���C���[�̈ʒu�ɕύX����

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
        Vector2 dis = new Vector2(targetPos.x, targetPos.y) - new Vector2(transform.position.x, transform.position.y);//�}�E�X�̈ʒu�ƒe�̏����ʒu�Ԃ̋������擾
        float rad = Mathf.Atan2(dis.y, dis.x);//��_�Ԃ̋�������p�x(���W�A��)�����߂�
        float sin = Mathf.Sin(rad);//���W�A������sin�����߂�
        float cos = Mathf.Cos(rad);//���W�A������cos�����߂�
        rb.velocity = new Vector2(cos * speed, sin * speed);//���߂�sincos�𑬓x�ɑ������
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.gameObject.CompareTag(Wall))
        //{
        //    Destroy(this.gameObject);//���̃I�u�W�F�N�g���폜
        //}

    }
}
