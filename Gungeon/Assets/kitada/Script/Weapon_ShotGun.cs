using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_ShotGun : Weapon
{
    [Header("===ショットガンの設定===")]
    [Header("発射する弾の数")][SerializeField] private int bulletNum;
    [Header("拡散する角度の幅")][SerializeField] private float diffusionAngle;

    private bool _isFire;//発射中

    protected override void Start()
    {
        base.Start();
    }

    public override void Fire()
    {
        GameObject player = GameObject.Find("Player");//プレイヤーのゲームオブジェクトを取得

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//マウスの位置を取得
        Vector2 dis = new Vector2(mousePos.x, mousePos.y) - new Vector2(transform.position.x, transform.position.y);//マウスの位置とプレイヤー距離を取得
        float rad = Mathf.Atan2(dis.x, dis.y);//二点間の距離から角度(ラジアン)を求める
    }


}
