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


    [Header("回避速度")][SerializeField] private float dodgeSpeed = 0;//回避中の速度
    [Header("回避時間")][SerializeField] private float dodgeTime = 0;//回避時間
    private bool isDodge = false;//回避中か否か


    private void Awake()
    {
        //リジッドボディの取得
        rb = GetComponent<Rigidbody2D>();

        //アニメーターの取得
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
        if (!isDodge)//回避中は移動しない
        {
            Vector2 newVelocity = new Vector2(horizontal, vertical) * speed;
            rb.velocity = newVelocity;
        }
    }

    private void HandleInput()
    {
        //方向チェックがメイン　= Rawを使う
        //慣性なしの移動
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    //回避の処理
    private void DodgeMove()
    {
        Vector2 dis = new Vector2(horizontal, vertical) - new Vector2(0, 0);//移動距離のベクトルを取得
        if (dis.magnitude > 0)//距離が0より大きいとき
        {
            float rad = Mathf.Atan2(dis.y, dis.x);//二点間の距離から角度(ラジアン)を求める 
            float sin = Mathf.Sin(rad);//ラジアンからsinを求める
            float cos = Mathf.Cos(rad);//ラジアンからcosを求める
            rb.velocity = new Vector2(cos * dodgeSpeed, sin * dodgeSpeed);//求めたsincosを速度に代入する
            isDodge = true;
            Invoke(nameof(DodgeSpan), dodgeTime);//dodgeTimeの分だけ遅らせてから呼び出す
            Debug.Log("回避");
        }
    }

    //回避のフラグをfalseに
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
