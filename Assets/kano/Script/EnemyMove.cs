using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    
    NavMeshAgent2D agent;//NavMesh2D���g�p���邽�߂̕ϐ�
    [SerializeField]
    Transform target;//�ǐՂ���I�u�W�F�N�g

    bool searchFlg;

    private void Start()
    {
        //NavMesh2D�̎擾
        agent = GetComponent<NavMeshAgent2D>();
    }

    private void Update()
    {
        //agent�̖ړI�n��ǐ�obj�̍��W�ɂ���
        agent.SetDestination(target.position);
    
        /*����
         * NavMeshAgent�X�N���v�g�̂ق��ňړ����s���Ă���̂ŁA
         * NavMesh�̃X�N���v�g�𗝉����ύX����K�v�����邩������Ȃ�
         */
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        searchFlg = true;
    }

}
