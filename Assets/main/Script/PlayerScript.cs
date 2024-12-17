using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    [SerializeField]
    public float HP;      //HP�̕ϐ�

    private Rigidbody2D rb;�@
    private float horizontal;
    private float vertical;

    private Animator animator;


    [Header("��𑬓x")][SerializeField] private float dodgeSpeed = 0;//��𒆂̑��x
    [Header("�������")][SerializeField] private float dodgeTime = 0;//�������
    private bool isDodge = false;//��𒆂��ۂ�


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
            Debug.Log("���");
        }
    }

    //����̃t���O��false��
    private void DodgeSpan()
    {
        isDodge = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("EnemyBullet"))
        {
            HP -= 1;
        }
    }

    public float GetHp()
    {
        return HP;
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
}
