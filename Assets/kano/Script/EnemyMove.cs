using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    
    NavMeshAgent2D agent;   //NavMesh2D���g�p���邽�߂̕ϐ�
    [SerializeField]
    Transform target;       //�ǐՂ���I�u�W�F�N�g

    
    [SerializeField]
    bool searchFlg = false;//�v���C���[�Ƃ̋�������

    [SerializeField] 
    private GameObject bullets;//�e

    [SerializeField]
    float attackTime;         //�U���^�C�~���O
    float timeCount;          //�b���J�E���g

    [SerializeField]
    int hp;                   //�̗�


    private void Start()
    {
        //NavMesh2D�̎擾
        agent = GetComponent<NavMeshAgent2D>();
    }

    private void Update()
    {
        if(!searchFlg)
        {
            //agent�̖ړI�n��ǐ�obj�̍��W�ɂ���
            agent.SetDestination(target.position);
        }
        timeCount += Time.deltaTime;

        if (timeCount > attackTime)
        {
            Attack();
            timeCount = 0;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            searchFlg = true;
        }
        if(collision.gameObject.CompareTag("PlayerBullet"))
        {
            Damage();
        }
    }

    private void Attack()
    {

        Instantiate(bullets, transform.position, Quaternion.identity);
    }

    private void Damage()
    {
        hp--;
        if (hp < 0) 
        { 
           Destroy(this.gameObject);
        }
    }
}
