using Unity.Mathematics;
using UnityEngine;

public class Weapon_MouseGun : Weapon
{
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
        angle = Mathf.Rad2Deg * rad;//�p�x���擾

        base.Fire();
    }
}
