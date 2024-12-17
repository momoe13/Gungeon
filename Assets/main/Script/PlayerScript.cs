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

    [SerializeField] private GameObject[] bullets;//���������z��

    private int weaponNumber;//����̑���
    private int weaponIndex = 0;//���݂̕���ԍ�
    private int[] bulletNumber;//���킲�Ƃ̒e��


    private void Awake()
    {
        //���W�b�h�{�f�B�̎擾
        rb = GetComponent<Rigidbody2D>();

        //�A�j���[�^�[�̎擾
        animator = GetComponent<Animator>();

        //����̗v�f�����擾
        weaponNumber = bullets.Length;
    }

    private void Update()
    {
        HandleInput();
        MoveAnimation();


        //E�L�[���������Ƃ��g�p���镐���ς���
        //����ԍ���ύX
        //���݂̕��킪����ԍ��̍Ō�̎��A����ԍ������Z�b�g����
        if (Input.GetKeyDown("e"))
        {
            if (weaponIndex == weaponNumber - 1)
            {
                weaponIndex = 0;
            }
            else
            {
                weaponIndex++;
            }
        }

        //�}�E�X���N���b�N�Œe�Ăяo��
        if (Input.GetMouseButtonDown(0))
        {
            UseWeapon();
        }

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

    //�e�̐����Ăяo��
    private void UseWeapon()
    {
        Instantiate(bullets[weaponIndex], transform.position, Quaternion.identity);//�e�𐶐�

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
