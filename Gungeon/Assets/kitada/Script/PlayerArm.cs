using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// ���������
public class PlayerArm : MonoBehaviour
{
    [Header("�������]�����锼�a")][SerializeField] private float radius;

    public Weapon[] weapons;//������i�[����z��
    public int curWeaponIdx;//���݂̕���ԍ�

    void Start()
    {
        InitWeapons();
    }

    void InitWeapons()//���������̐ݒ�
    {
        curWeaponIdx = 0;//��������̔ԍ���ݒ�
        weapons =  this.GetComponentsInChildren<Weapon>();//Arm�̎q�I�u�W�F�N�g��<Wepon>�������̂𕐊�Ƃ��Ď擾
        if (weapons == null)
        {
            Debug.LogWarning("����Ȃ���");
        }
        for (int i = 0; i < weapons.Length; i++)//�S�Ă̕�����A�N�e�B�u��
        {
            weapons[i].gameObject.SetActive(false);
        }
        if (weapons[curWeaponIdx] != null) weapons[curWeaponIdx].gameObject.SetActive(true);//����������A�N�e�B�u��
    }

    // Update is called once per frame
    void Update()
    {
        //���݂̕�����g�p����
        if (Input.GetMouseButtonDown(0)) weapons[curWeaponIdx].isTrigger = true;

        //���݂̕�����g�p����߂�
        if (Input.GetMouseButtonUp(0)) weapons[curWeaponIdx].isTrigger = false;

        //�����[�h
        if (Input.GetKeyDown(KeyCode.R)) Reload();

        if (Input.GetKeyDown(KeyCode.E))//����ύX
        {
            if (weapons[curWeaponIdx].isReloading) return;
            weapons[curWeaponIdx].isTrigger = false;
            ChangeWeapon();
        }

        RotateArm();//�r�̉�]
    }
    private void ChangeWeapon()//����ύX
    {
        //���݂̕���ȊO���A�N�e�B�u��
        if (weapons[curWeaponIdx] != null) weapons[curWeaponIdx].gameObject.SetActive(false);
        
        curWeaponIdx += 1;//����ԍ���ύX
        if (curWeaponIdx >= weapons.Length) curWeaponIdx = 0;//�Ō�̕���̏ꍇ�ŏ��̕���ɖ߂�

        if (weapons[curWeaponIdx] != null) weapons[curWeaponIdx].gameObject.SetActive(true);//��������������A�N�e�B�u��
    }
    private void Reload()
    {
        weapons[curWeaponIdx].Reload();//�������Ă��镐��������[�h����
    }

    private void RotateArm()
    {
        GameObject obj = transform.parent.gameObject;//�e�I�u�W�F�N�g���擾

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//�}�E�X�̈ʒu���擾
        Vector2 dis = new Vector2(mousePos.x, mousePos.y) - new Vector2(obj.transform.position.x, obj.transform.position.y);//�}�E�X�̈ʒu�Ɛe�I�u�W�F�N�g�̋������擾
        //��_�Ԃ̋�������radian,sin,cos�����߂� 
        float rad = Mathf.Atan2(dis.x, dis.y);
        float sin = Mathf.Sin(rad);
        float cos = Mathf.Cos(rad);

        this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -Mathf.Rad2Deg * rad);//�}�E�X�����ɉ����ăI�u�W�F�N�g����]������
        this.transform.position = new Vector2(obj.transform.position.x, obj.transform.position.y) + new Vector2(sin * radius, cos * radius);//���߂��p�x����r���~��Ɉړ�������
    }
}
