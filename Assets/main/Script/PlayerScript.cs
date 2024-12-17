using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    [SerializeField]
    public float HP;      //HPの変数

    private Rigidbody2D rb;　
    private float horizontal;
    private float vertical;

    private Animator animator;

    [SerializeField] private GameObject[] bullets;//武器を入れる配列

    private int weaponNumber;//武器の総数
    private int weaponIndex = 0;//現在の武器番号
    private int[] bulletNumber;//武器ごとの弾数


    private void Awake()
    {
        //リジッドボディの取得
        rb = GetComponent<Rigidbody2D>();

        //アニメーターの取得
        animator = GetComponent<Animator>();

        //武器の要素数を取得
        weaponNumber = bullets.Length;
    }

    private void Update()
    {
        HandleInput();
        MoveAnimation();


        //Eキーを押したとき使用する武器を変える
        //武器番号を変更
        //現在の武器が武器番号の最後の時、武器番号をリセットする
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
        Instantiate(bullets[weaponIndex], transform.position, Quaternion.identity);//弾を生成

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
