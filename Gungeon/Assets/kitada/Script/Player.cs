using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject bullets;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
     
        if (Input.GetMouseButtonDown(0))
        {
            UseWeapon();
        }

    }

    //
    private void UseWeapon()
    {
        
        //TODO:�e���Ƃɕ�����K�v������
        Instantiate(bullets, transform.position, Quaternion.identity);
    }
    
}
