using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private Rigidbody2D rb;
    private float horizontal;
    private float vertical;

    private void Awake()
    {
        //���W�b�h�{�f�B�̎擾
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
        //�����`�F�b�N�����C���@= Raw���g��
        //�����Ȃ��̈ړ�
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }
}
