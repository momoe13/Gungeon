using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMove : MonoBehaviour
{
    [SerializeField]
    Transform player;   //�v���C���[�̈ʒu

    [SerializeField]
    Transform enemy;    //�e�I�u�W�F�N�g�̈ʒu

    [SerializeField]
    private float radius;//�~�`�Ɉړ��͈͂ɐ�����������~�̔��a

    private void Awake()
    {
        //�e�I�u�W�F�N�g�̈ʒu���擾
        enemy = this.gameObject.transform.parent.gameObject.transform;
    }

    private void Update()
    {
        float distance = Vector3.Distance(player.transform.position, enemy.transform.position);

        if (distance > radius)
        {
            Vector3 GunPos = (player.transform.position - enemy.transform.position).normalized;

            //�ړ�������
            this.transform.localPosition = GunPos * radius;

        }
    }
}
