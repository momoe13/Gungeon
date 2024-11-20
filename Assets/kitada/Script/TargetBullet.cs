using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBullet : MonoBehaviour
{
    [SerializeField] private float speed;//�e�̑��x
    [SerializeField] private string attackTag;//�e��Tag

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Shot();
    }

    private void Shot()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//�}�E�X�̍��W���擾
        Vector2 dis = new Vector2(mousePos.x, mousePos.y) - new Vector2(transform.position.x, transform.position.y);//�}�E�X�̈ʒu�ƒe�̏����ʒu�Ԃ̋������擾
        float rad = Mathf.Atan2(dis.y, dis.x);//��_�Ԃ̋�������p�x(���W�A��)�����߂� 
        float sin = Mathf.Sin(rad);//���W�A������sin�����߂�
        float cos = Mathf.Cos(rad);//���W�A������cos�����߂�
        rb.velocity = new Vector2(cos * speed, sin * speed);//���߂�sincos�𑬓x�ɑ������
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != attackTag && collision.tag != attackTag + "Attack")//�e��������L�����ȊO������Tag�ȊO�̃I�u�W�F�N�g�ɐG�ꂽ�Ƃ�
        {
            Destroy(this.gameObject);//���̃I�u�W�F�N�g���폜
            
        }
    }
}
