using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    [SerializeField] float HP;      //HP�̕ϐ�
    public GameObject HPUIobj_1;
    public GameObject HPUIobj_2;
    public GameObject HPUIobj_3;

    [SerializeField]
    GameObject player;
    PlayerManager playersc;

    private void Start()
    {
        playersc = player.GetComponent<PlayerManager>();
    }

    //�G�̒e�ɓ�����������HP�����炷����
    //private void OnTriggerEnter2D(Collider2D col)
    //{
    //    if (col.gameObject.tag == "EnemyBullet")
    //    {
    //        HP -= 1;
    //    }
    //}

    private void Update()           //HP���[���ɂȂ����Ƃ��ɃQ�[���I�[�o�[�V�[�����Ăяo��
    {

        float HP = playersc.GetHp();
        switch (HP)
        {
            case 0:
                HPUIobj_3.SetActive(false);
                break;

            case 1:
                HPUIobj_2.SetActive(false);
                break;

            case 2:
                HPUIobj_1.SetActive(false);
                break;
            case 3:
                break;




        }
        //if (HP <= 0)
        //{
        //    //GameOverScene();
        //}

        //if (HP <= 2)
        //{
        //    HPUIobj_1.SetActive(false);
        //}
        //else if (HP <= 1)
        //{
        //    HPUIobj_2.SetActive(false);
        //}
    }

    private void GameOverScene()    //�Q�[���I�[�o�[�V�[���̌Ăяo��
    {
        SceneManager.LoadScene("GameOver");
    }
}
