using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class WeponUI : MonoBehaviour
{
    [Header("PlayerArm")][SerializeField] private PlayerArm pArm;
    [Header("銃の名前")][SerializeField] private GameObject nameUI;
    [Header("残弾")][SerializeField] private GameObject numUI;
    [Header("武器番号")][SerializeField] private GameObject weaponIndexUI;
    [Header("リロード")][SerializeField] private GameObject reloadUI;
    [Header("リロードバー")][SerializeField] private GameObject reloadBar;
    [Header("弾数警告")][SerializeField] private GameObject warningUI;

    [Header("警告点滅間隔")][SerializeField] private float blinkTime;

    private int curIdx;//武器の番号
    private float timer = 0f;
    private Text nameText, numText, indexText, reloadText, warningText;

    void Start()
    {
        TextComponent();
        warningUI.SetActive(false);
        reloadUI.SetActive(false);
        reloadBar.SetActive(false);
    }

    void Update()
    {
        EnptyText();//段数が0の時のUI表示
        ReloadUI();//リロード中のUI表示
        DisplayUI(); //常に表示するUI 
    }

    private void DisplayUI()
    {
        curIdx = pArm.curWeaponIdx + 1;
        
        //武器番号
        //武器の名前
        //武器の最大弾数と残弾の表示
        indexText.text = "[" + curIdx + "]";
        nameText.text = pArm.weapons[pArm.curWeaponIdx].weaponName;
        numText.text = pArm.weapons[pArm.curWeaponIdx].curBulletRemain + "/" + pArm.weapons[pArm.curWeaponIdx].MaxBulletNum;
    }

    private void ReloadUI()
    {
        //リロード中に関するUIを表示
        reloadBar.SetActive(pArm.weapons[pArm.curWeaponIdx].isReloading);
        reloadUI.SetActive(pArm.weapons[pArm.curWeaponIdx].isReloading);

        if (!pArm.weapons[pArm.curWeaponIdx].isReloading)return;
        warningUI.SetActive(false);//弾数警告を非表示

        //リロードバーにリロード時間を受け渡す
        //リロードバーを動かす
        reloadBar.GetComponent<ReloadBar>().reloadTime = pArm.weapons[pArm.curWeaponIdx].reloadTime;
        reloadBar.GetComponent<ReloadBar>().isReload = true;
    }

    private void EnptyText()
    {
        if (pArm.weapons[pArm.curWeaponIdx].curBulletRemain == 0)
        {
            numText.color = Color.red;//残弾表示のUIを赤色にする

            //弾数警告UIを点滅させる処理
            warningUI.SetActive(true);
            timer += Time.deltaTime;
            if (timer > blinkTime && timer < blinkTime * 2)
            {
                warningUI.SetActive(false);
            }
            else if (timer >= blinkTime * 2)
            {
                warningUI.SetActive(true);
                timer = 0;
            }
        }
        else
        {
            numText.color = Color.white;//残弾表示のUIを白色にする
            warningUI.SetActive(false);
        }
    }
    private void TextComponent()//テキストのコンポーネントを取得
    {
        nameText = nameUI.GetComponent<Text>();
        numText = numUI.GetComponent<Text>();
        indexText = weaponIndexUI.GetComponent<Text>();
        reloadText = reloadUI.GetComponent<Text>();
        warningText = warningUI.GetComponent<Text>();
    }
}
