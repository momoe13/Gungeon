using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_ShotGun : Weapon
{
    [Header("===�V���b�g�K���̐ݒ�===")]
    [Header("���˂���e�̐�")][SerializeField] private int bulletNum;
    [Header("�g�U����p�x�̕�")][SerializeField] private float diffusionAngle;

    private bool _isFire;//���˒�

    protected override void Start()
    {
        base.Start();
    }

    public override void Fire()
    {
        GameObject player = GameObject.Find("Player");//�v���C���[�̃Q�[���I�u�W�F�N�g���擾

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//�}�E�X�̈ʒu���擾
        Vector2 dis = new Vector2(mousePos.x, mousePos.y) - new Vector2(transform.position.x, transform.position.y);//�}�E�X�̈ʒu�ƃv���C���[�������擾
        float rad = Mathf.Atan2(dis.x, dis.y);//��_�Ԃ̋�������p�x(���W�A��)�����߂�
    }


}
