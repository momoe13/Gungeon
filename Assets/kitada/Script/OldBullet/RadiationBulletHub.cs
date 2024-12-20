using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiationBulletHub : MonoBehaviour
{
    public static List<GameObject> bullets = new List<GameObject>();//弾を管理するリスト

    [HideInInspector] public float degBullet;//弾道の角度

    public int bNum;//弾数

    [SerializeField] private GameObject bullet;
    [SerializeField] private float speed;//弾の速度
    [SerializeField] private float startDeg = 0f;//弾の出始める角度
    [SerializeField] private int bulletNumber;//弾の数
    [SerializeField] private string attackTag;//弾のTag

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Generate();
    }

    private void Generate()//弾の生成
    {
        for (int i = 0; i < bulletNumber; i++)
        {
            Debug.Log("a");
            var b = Instantiate(bullet, transform.position, Quaternion.identity);//弾の生成
            bullets.Add(b);//生成した弾をリストに追加
            Fire(b.GetComponent<RBullet>(),i);
        }
        Destroy(this.gameObject);//一秒後にHubを削除
    }

    private void  Fire(RBullet b,int i)//弾に情報を渡す
    {
        float bulletRad = 360 / bulletNumber;//弾間の角度を求める
        if (b == null) 
        {
            Debug.LogError("弾がない");
            return;
        }
        b.deg = bulletRad * (i + 1) + startDeg;//角度の受け渡し
        b.speed = speed;//速度の受け渡し
        b.aTag = attackTag;//タグの受け渡し
        b.Shot();//弾の関数Shotを実行
    }
}
