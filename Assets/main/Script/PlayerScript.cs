using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    [SerializeField]
    public float HP;      //HP�̕ϐ�

    private Rigidbody2D rb;
    private float horizontal;
    private float vertical;


    [SerializeField] private GameObject bullets;

    private void Awake()
    {
        //���W�b�h�{�f�B�̎擾
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleInput();


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
        Instantiate(bullets, transform.position, Quaternion.identity);

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
}
