using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Radiation : Weapon
{
    [Header("===円状に広がる弾の設定===")]
    [Header("発射する弾数")][SerializeField] private int bulletNum;
    [Header("弾ので始める角度")][SerializeField] private int startAntgle;

    private bool _isFire;//発射中

    protected override void Start()
    {
        base.Start();
    }
    private void Update()
    {
        if (isTrigger)//射撃ボタンが押されている時
        {
            Fire();//射撃
            if (!auto) isTrigger = false;//手動武器の場合射撃ボタンのフラグを降ろす
        }
    }

    public override void Fire()
    {
        if (_isFire) return;//射撃中なら処理を行わない
        float deg = 360 / bulletNum;//弾間の角度を求める

        for (int i = 0; i < bulletNum; i++)
        {
            base.isFire = false;
            angle = deg * i + startAntgle;//弾ごとの角度を代入
            base.Fire();
        }
        //発射中のフラグを立てる
        //指定したrate間開けて発射中のフラグを降ろす
        _isFire = true;
        Invoke(nameof(ReFire), rate);
    }

    private void ReFire()
    {
         _isFire = false;//発射中のフラグを降ろす
    }
}
