using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    [SerializeField]
    public float HP;      //HP�̕ϐ�

    private Rigidbody2D rb;
    private float horizontal;
    private float vertical;



    [SerializeField] private GameObject[] bullets;//���������z��

    private int weaponNumber;//����̑���
    private int weaponIndex = 0;//���݂̕���ԍ�
    private int[] bulletNumber;//���킲�Ƃ̒e��


    private void Awake()
    {
        //���W�b�h�{�f�B�̎擾
        rb = GetComponent<Rigidbody2D>();

        //����̗v�f�����擾
        weaponNumber = bullets.Length;
    }

    private void Update()
    {
        HandleInput();


        
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
}
