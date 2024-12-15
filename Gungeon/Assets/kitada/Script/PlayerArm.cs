using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// 武器を撃つ
public class PlayerArm : MonoBehaviour
{
    [Header("武器を回転させる半径")][SerializeField] private float radius;

    public Weapon[] weapons;//武器を格納する配列
    public int curWeaponIdx;//現在の武器番号

    void Start()
    {
        InitWeapons();
    }

    void InitWeapons()//初期装備の設定
    {
        curWeaponIdx = 0;//初期武器の番号を設定
        weapons =  this.GetComponentsInChildren<Weapon>();//Armの子オブジェクトで<Wepon>を持つものを武器として取得
        if (weapons == null)
        {
            Debug.LogWarning("武器ないよ");
        }
        for (int i = 0; i < weapons.Length; i++)//全ての武器を非アクティブ化
        {
            weapons[i].gameObject.SetActive(false);
        }
        if (weapons[curWeaponIdx] != null) weapons[curWeaponIdx].gameObject.SetActive(true);//初期武器をアクティブ化
    }

    // Update is called once per frame
    void Update()
    {
        //現在の武器を使用する
        if (Input.GetMouseButtonDown(0)) weapons[curWeaponIdx].isTrigger = true;

        //現在の武器を使用をやめる
        if (Input.GetMouseButtonUp(0)) weapons[curWeaponIdx].isTrigger = false;

        //リロード
        if (Input.GetKeyDown(KeyCode.R)) Reload();

        if (Input.GetKeyDown(KeyCode.E))//武器変更
        {
            if (weapons[curWeaponIdx].isReloading) return;
            weapons[curWeaponIdx].isTrigger = false;
            ChangeWeapon();
        }

        RotateArm();//腕の回転
    }
    private void ChangeWeapon()//武器変更
    {
        //現在の武器以外を非アクティブ化
        if (weapons[curWeaponIdx] != null) weapons[curWeaponIdx].gameObject.SetActive(false);
        
        curWeaponIdx += 1;//武器番号を変更
        if (curWeaponIdx >= weapons.Length) curWeaponIdx = 0;//最後の武器の場合最初の武器に戻る

        if (weapons[curWeaponIdx] != null) weapons[curWeaponIdx].gameObject.SetActive(true);//装備した武器をアクティブ化
    }
    private void Reload()
    {
        weapons[curWeaponIdx].Reload();//装備している武器をリロードする
    }

    private void RotateArm()
    {
        GameObject obj = transform.parent.gameObject;//親オブジェクトを取得

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//マウスの位置を取得
        Vector2 dis = new Vector2(mousePos.x, mousePos.y) - new Vector2(obj.transform.position.x, obj.transform.position.y);//マウスの位置と親オブジェクトの距離を取得
        //二点間の距離からradian,sin,cosを求める 
        float rad = Mathf.Atan2(dis.x, dis.y);
        float sin = Mathf.Sin(rad);
        float cos = Mathf.Cos(rad);

        this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -Mathf.Rad2Deg * rad);//マウス方向に応じてオブジェクトを回転させる
        this.transform.position = new Vector2(obj.transform.position.x, obj.transform.position.y) + new Vector2(sin * radius, cos * radius);//求めた角度から腕を円状に移動させる
    }
}
