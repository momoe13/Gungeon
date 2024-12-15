using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadBar : MonoBehaviour
{
    [Header("動く点")][SerializeField] GameObject movePoint;
    [Header("始点")][SerializeField] GameObject firstPoint;
    [Header("終点")][SerializeField] GameObject lastPoint;

    [HideInInspector]public float reloadTime;//リロード時間
    [HideInInspector]public bool isReload = false;

    private void Start()
    {
        movePoint.transform.position = firstPoint.transform.position;//動く点を初期位置にセット
    }
    void Update()
    {
        if(!isReload) return;

        float dis = lastPoint.transform.position.x - firstPoint.transform.position.x;//始点と終点の距離を求める
        float spe = dis / reloadTime;//距離を時間で割って速さを求める
        movePoint.transform.Translate(spe * Time.deltaTime, 0, 0);//動く点を求めた速度で動かす

        if (movePoint.transform.position.x >= lastPoint.transform.position.x)//動く点が終点まで行ったとき
        {
            movePoint.transform.position = firstPoint.transform.position;//動く点を初期位置に戻す
            isReload = false;//リロードを終える
        }
    }

}
