using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{

    [SerializeField] 
    private GameObject bullets;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           UseWeapon();
        }
    }


    private void UseWeapon()
    {

        //TODO:�e���Ƃɕ�����K�v������
        Instantiate(bullets, transform.position, Quaternion.identity);
    }
}
