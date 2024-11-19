using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private GameObject[] bullets;//武器を入れる配列

    private int weaponNumber;//武器の総数
    private int weaponIndex = 0;//現在の武器番号

    void Start()
    {
        weaponNumber = bullets.Length;//武器の要素数を取得
    }

    // Update is called once per frame
    void Update()
    {
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

        if (Input.GetMouseButtonDown(0))
        {
            UseWeapon();
        }

    }

    private void UseWeapon()
    {
        Instantiate(bullets[weaponIndex], transform.position, Quaternion.identity);//弾を生成
    }
    
}
