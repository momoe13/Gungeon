using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Radiation : Weapon
{
    [Header("===�~��ɍL����e�̐ݒ�===")]
    [Header("���˂���e��")][SerializeField] private int bulletNum;
    [Header("�e�̂Ŏn�߂�p�x")][SerializeField] private int startAntgle;

    private bool _isFire;//���˒�

    protected override void Start()
    {
        base.Start();
    }
    private void Update()
    {
        if (isTrigger)//�ˌ��{�^����������Ă��鎞
        {
            Fire();//�ˌ�
            if (!auto) isTrigger = false;//�蓮����̏ꍇ�ˌ��{�^���̃t���O���~�낷
        }
    }

    public override void Fire()
    {
        if (_isFire) return;//�ˌ����Ȃ珈�����s��Ȃ�
        float deg = 360 / bulletNum;//�e�Ԃ̊p�x�����߂�

        for (int i = 0; i < bulletNum; i++)
        {
            base.isFire = false;
            angle = deg * i + startAntgle;//�e���Ƃ̊p�x����
            base.Fire();
        }
        //���˒��̃t���O�𗧂Ă�
        //�w�肵��rate�ԊJ���Ĕ��˒��̃t���O���~�낷
        _isFire = true;
        Invoke(nameof(ReFire), rate);
    }

    private void ReFire()
    {
         _isFire = false;//���˒��̃t���O���~�낷
    }
}
