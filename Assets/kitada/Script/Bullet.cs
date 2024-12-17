using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private string attackTag;//�e���g�p����I�u�W�F�N�g�̃^�O������
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void SetVelocity(Vector2 vel)//���x����
    { 
        _rb.velocity = vel;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //����Tag�̒e���e��������I�u�W�F�N�g�ȊO�ɓ���������
        //�e���폜
        if(collision.tag == this.tag) return;
        if(collision.tag == attackTag) return;
        Destroy(this.gameObject);
    }
}
