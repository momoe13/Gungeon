using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    [SerializeField]
    public float HP;      //HPの変数

    private Rigidbody2D rb;
    private float horizontal;
    private float vertical;


    [SerializeField] private GameObject bullets;

    private void Awake()
    {
        //リジッドボディの取得
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleInput();


        //マウス左クリックで弾呼び出し
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
        //方向チェックがメイン　= Rawを使う
        //慣性なしの移動
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    //弾の生成呼び出し
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
