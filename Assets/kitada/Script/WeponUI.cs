using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class WeponUI : MonoBehaviour
{
    [Header("PlayerArm")][SerializeField] private PlayerArm pArm;
    [Header("�e�̖��O")][SerializeField] private GameObject nameUI;
    [Header("�c�e")][SerializeField] private GameObject numUI;
    [Header("����ԍ�")][SerializeField] private GameObject weaponIndexUI;
    [Header("�����[�h")][SerializeField] private GameObject reloadUI;
    [Header("�����[�h�o�[")][SerializeField] private GameObject reloadBar;
    [Header("�e���x��")][SerializeField] private GameObject warningUI;

    [Header("�x���_�ŊԊu")][SerializeField] private float blinkTime;

    private int curIdx;//����̔ԍ�
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
        EnptyText();//�i����0�̎���UI�\��
        ReloadUI();//�����[�h����UI�\��
        DisplayUI(); //��ɕ\������UI 
    }

    private void DisplayUI()
    {
        curIdx = pArm.curWeaponIdx + 1;
        
        //����ԍ�
        //����̖��O
        //����̍ő�e���Ǝc�e�̕\��
        indexText.text = "[" + curIdx + "]";
        nameText.text = pArm.weapons[pArm.curWeaponIdx].weaponName;
        numText.text = pArm.weapons[pArm.curWeaponIdx].curBulletRemain + "/" + pArm.weapons[pArm.curWeaponIdx].MaxBulletNum;
    }

    private void ReloadUI()
    {
        //�����[�h���Ɋւ���UI��\��
        reloadBar.SetActive(pArm.weapons[pArm.curWeaponIdx].isReloading);
        reloadUI.SetActive(pArm.weapons[pArm.curWeaponIdx].isReloading);

        if (!pArm.weapons[pArm.curWeaponIdx].isReloading)return;
        warningUI.SetActive(false);//�e���x�����\��

        //�����[�h�o�[�Ƀ����[�h���Ԃ��󂯓n��
        //�����[�h�o�[�𓮂���
        reloadBar.GetComponent<ReloadBar>().reloadTime = pArm.weapons[pArm.curWeaponIdx].reloadTime;
        reloadBar.GetComponent<ReloadBar>().isReload = true;
    }

    private void EnptyText()
    {
        if (pArm.weapons[pArm.curWeaponIdx].curBulletRemain == 0)
        {
            numText.color = Color.red;//�c�e�\����UI��ԐF�ɂ���

            //�e���x��UI��_�ł����鏈��
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
            numText.color = Color.white;//�c�e�\����UI�𔒐F�ɂ���
            warningUI.SetActive(false);
        }
    }
    private void TextComponent()//�e�L�X�g�̃R���|�[�l���g���擾
    {
        nameText = nameUI.GetComponent<Text>();
        numText = numUI.GetComponent<Text>();
        indexText = weaponIndexUI.GetComponent<Text>();
        reloadText = reloadUI.GetComponent<Text>();
        warningText = warningUI.GetComponent<Text>();
    }
}
