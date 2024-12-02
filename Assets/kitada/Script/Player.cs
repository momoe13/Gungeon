using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private Rigidbody2D rb;
    private float horizontal;
    private float vertical;
    //----
    [SerializeField] private float dodgeSpeed = 0;//��𒆂̑��x
    [SerializeField] private float dodgeTime = 0;//�������
    private bool isDodge = false;//��𒆂��ۂ�

    private void Awake()
    {
        //���W�b�h�{�f�B�̎擾
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleInput();
        //----
        if (Input.GetMouseButtonDown(1) && !isDodge)
        {
            DodgeMove();
        }
    }

    private void FixedUpdate()
    {
        if (!isDodge)//��𒆂͈ړ����Ȃ�
        {
            Vector2 newVelocity = new Vector2(horizontal, vertical) * speed;
            rb.velocity = newVelocity;
        }
    }

    private void HandleInput()
    {
        //�����`�F�b�N�����C���@= Raw���g��
        //�����Ȃ��̈ړ�
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    //----
    //����̏���
    private void DodgeMove()
    {
        Vector2 dis = new Vector2(horizontal, vertical) - new Vector2(0, 0);//�ړ������̃x�N�g�����擾
        if (dis.magnitude > 0)//������0���傫���Ƃ�
        {
            float rad = Mathf.Atan2(dis.y, dis.x);//��_�Ԃ̋�������p�x(���W�A��)�����߂� 
            float sin = Mathf.Sin(rad);//���W�A������sin�����߂�
            float cos = Mathf.Cos(rad);//���W�A������cos�����߂�
            rb.velocity = new Vector2(cos * dodgeSpeed, sin * dodgeSpeed);//���߂�sincos�𑬓x�ɑ������
            isDodge = true;
            Invoke(nameof(DodgeSpan), dodgeTime);//dodgeTime�̕������x�点�Ă���Ăяo��
        }
    }

    //����̃t���O��false��
    private void DodgeSpan()
    {
        isDodge = false;
    }

    //HP�Ǘ��������isDodge���g���Ă�������
}
