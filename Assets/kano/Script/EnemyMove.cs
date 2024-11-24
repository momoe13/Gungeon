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
    bool searchFlg = false; //�v���C���[�Ƃ̋�������

    [SerializeField] 
    private GameObject bullets;//�e

    private Transform gun; 

    [SerializeField]
    float attackTime;         //�U���^�C�~���O
    float timeCount;          //�b���J�E���g

    [SerializeField]
    int attackCount;          //�����[�h�܂ł̃J�E���g
    
    [SerializeField]
    float reloadTime;         //�����[�h�̕b��
    
    [SerializeField]
    int hp;                   //�̗�


    private void Start()
    {
        //NavMesh2D�̎擾
        agent = GetComponent<NavMeshAgent2D>();


        //�e���ˈʒu�̎擾
        gun = transform.Find("Gun").transform;

    }

    private void Update()
    {
        if(!searchFlg)
        {
            //agent�̖ړI�n��ǐ�obj�̍��W�ɂ���
            agent.SetDestination(target.position);
        }
        timeCount += Time.deltaTime;

        //�J�E���g���U�����Ԃ���������U��
        if (timeCount > attackTime)
        {
            //�U���֐��Ăяo��
            Attack();

            //�J�E���g0�ɖ߂�
            timeCount = 0;

            //�����[�h�̃J�E���g�_�E��
            attackCount--;
        }

        //TODO:�����[�h����

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�T�[�`�͈͂Ƀv���C���[�����������~
        if (collision.gameObject.CompareTag("Player"))
        {
            searchFlg = true;
        }
      
    }

    //�G�{�̂̓����蔻��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�v���C���[�̒e�ɓ���������HP����
        if (collision.gameObject.CompareTag("PlayerAttack"))
        {
            Damage();
        }
    }

    private void Attack()
    {
        //TODO:01 �v���C���[�̈ʒu���擾���A�v���C���[�ɋ߂��ʒu����e�𐶐�
        Instantiate(bullets, gun.position, Quaternion.identity);
    }

    //�_���[�W����
    private void Damage()
    {
        hp--;
        //HP��0�ȉ��ɂȂ�����I�u�W�F�N�g����
        if (hp <= 0) 
        { 
           Destroy(this.gameObject);
        }
    }
}


