using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [Header("銃の名前")][SerializeField] public string weaponName;
    [Header("発射する弾")][SerializeField] private Bullet bullet;
    [Header("弾数")][SerializeField] public int MaxBulletNum;
    [Header("発射速度")][SerializeField] private float speed;
    [Header("発射レート")][SerializeField] public float rate;
    [Header("リロード時間")][SerializeField] public float reloadTime;
    [Header("角度")][SerializeField] protected float angle;
    [Header("連射")][SerializeField] public bool auto;

    //今だけ確認のためにSerializeField
    [SerializeField] public int curBulletRemain;//残弾
    [SerializeField] public bool isReloading;//リロード中
    public bool isTrigger;//射撃ボタンを押している
    public bool isFire;//射撃中
    private Vector2 direction;//方向
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    protected virtual void Start()
    {
        curBulletRemain = MaxBulletNum;//残弾を補充
    }

    private void Update()
    {
        if (isTrigger)//射撃ボタンが押されている時
        {
            Fire();//射撃
            if (!auto) isTrigger = false;//手動武器の場合射撃ボタンのフラグを降ろす
        }
    }

    public virtual void Fire()
    {
        //弾が装備されていない時
        //残弾が0のとき
        //リロード中の時
        //射撃中の時
        //Fireメソッドを行わない
        if (bullet == null) { Debug.Log("弾がない"); return; }
        if (curBulletRemain <= 0) { Debug.Log("残弾0");return; }
        if (isReloading) { Debug.Log("リロード中"); return; }
        if (isFire) { return; }

            curBulletRemain--;//残弾数を減らす
            float rad = angle * Mathf.Deg2Rad;//角度をラジアンに変換
            //sin,cosを求める
            float sin = Mathf.Sin(rad);
            float cos = Mathf.Cos(rad);

            direction = new Vector2(sin, cos);//角度としてsin,cosを代入
            var b = Instantiate(bullet, transform.position, Quaternion.identity);//弾を生成
            b.SetVelocity(direction.normalized * speed);//弾に速度を代入

            //発射中のフラグを立てる
            //指定したrate間開けて発射中のフラグを降ろす
            isFire = true;
            Invoke(nameof(OnFire), rate);
    }


    private void OnFire()
    {
        isFire = false;//発射中のフラグを降ろす
    }

    public void Reload()
    {
        if (isReloading) return;//リロード中ならこの処理を行わない
        if (curBulletRemain == MaxBulletNum) return;//弾数が満タンの時この処理を行わない
        Debug.Log("リロード中");
        isReloading = true;//リロード中フラグを立てる
        Invoke(nameof(OnReload), reloadTime);//リロードのメソッドをreloadTime分間隔を開けて呼び出す
    }

    public void OnReload()
    {
        Debug.Log("リロード完了");
        curBulletRemain = MaxBulletNum;//残弾を最大弾数にする
        isReloading = false;//リロードを終える
    }
}
