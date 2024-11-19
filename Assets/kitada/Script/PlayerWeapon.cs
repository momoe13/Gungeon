using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private GameObject[] bullets;//���������z��

    private int weaponNumber;//����̑���
    private int weaponIndex = 0;//���݂̕���ԍ�

    void Start()
    {
        weaponNumber = bullets.Length;//����̗v�f�����擾
    }

    // Update is called once per frame
    void Update()
    {
        //E�L�[���������Ƃ��g�p���镐���ς���
        //����ԍ���ύX
        //���݂̕��킪����ԍ��̍Ō�̎��A����ԍ������Z�b�g����
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
        Instantiate(bullets[weaponIndex], transform.position, Quaternion.identity);//�e�𐶐�
    }
    
}
