using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiationBulletHub : MonoBehaviour
{
    public static List<GameObject> bullets = new List<GameObject>();//�e���Ǘ����郊�X�g

    [HideInInspector] public float degBullet;//�e���̊p�x

    [SerializeField] private GameObject bullet;
    [SerializeField] private float speed;//�e�̃X�s�[�h
    [SerializeField] private float startDeg = 0f;//�e�̏o�n�߂�p�x
    [SerializeField] private int bulletNumber;//�e�̐�

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Generate();
    }

    private void Generate()//�e�̐���
    {
        for (int i = 0; i < bulletNumber; i++)
        {
            var b = Instantiate(bullet, transform.position, Quaternion.identity);//�e�̐���
            bullets.Add(b);//���������e�����X�g�ɒǉ�
            Fire(b.GetComponent<RBullet>(),i);
        }
    }

    private void Fire(RBullet b,int i)//�e�ɏ���n��
    {
        float bulletRad = 360 / bulletNumber;//�e�Ԃ̊p�x�����߂�
        if (b == null) 
        {
            Debug.LogError("�e���Ȃ�");
            return;
        }
        b.deg = bulletRad * (i + 1) + startDeg;//�p�x�̎󂯓n��
        b.speed = speed;//���x�̎󂯓n��
        b.Shot();//�e�̊֐�Shot�����s
    }
}
