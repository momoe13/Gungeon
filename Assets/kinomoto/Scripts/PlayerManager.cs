using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField]
    public float HP;      //HP�̕ϐ�

    private Rigidbody2D rb;
    private float horizontal;
    private float vertical;
    private Animator animator;

    private void Awake()
    {
        //���W�b�h�{�f�B�̎擾
        rb = GetComponent<Rigidbody2D>();

        //�A�j���[�^�[�̎擾
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleInput();
        MoveAnimation();
    }

    private void FixedUpdate()
    {
        Vector2 newVelocity = new Vector2(horizontal, vertical) * speed;
        rb.velocity = newVelocity;
    }

    private void HandleInput()
    {
        //�����`�F�b�N�����C���@= Raw���g��
        //�����Ȃ��̈ړ�
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void MoveAnimation()
    {
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Up", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Left", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("Down", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Right", true);
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A)
            || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
        }

        if (HP == 0)
        {
            animator.SetBool("Gameover", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("EnemyBullet"))
        {
            Debug.Log("��������");
            HP -= 1;
        }
    }

    public float GetHp()
    {
        return HP;
    }
}
