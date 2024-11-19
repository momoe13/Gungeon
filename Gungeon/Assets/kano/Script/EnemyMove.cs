using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    
    NavMeshAgent2D agent;//NavMesh2D���g�p���邽�߂̕ϐ�
    [SerializeField]
    Transform target;//�ǐՂ���I�u�W�F�N�g

    
    [SerializeField]
    bool searchFlg = false;//�v���C���[�Ƃ̋�������


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
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            searchFlg = true;
        }
    }

}
