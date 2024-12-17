using Unity.Mathematics;
using UnityEngine;

public class Weapon_MouseGun : Weapon
{
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
        angle = Mathf.Rad2Deg * rad;//角度を取得

        base.Fire();
    }
}
