using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [Header("�e�̖��O")][SerializeField] public string weaponName;
    [Header("���˂���e")][SerializeField] private Bullet bullet;
    [Header("�e��")][SerializeField] public int MaxBulletNum;
    [Header("���ˑ��x")][SerializeField] private float speed;
    [Header("���˃��[�g")][SerializeField] public float rate;
    [Header("�����[�h����")][SerializeField] public float reloadTime;
    [Header("�p�x")][SerializeField] protected float angle;
    [Header("�A��")][SerializeField] public bool auto;

    //�������m�F�̂��߂�SerializeField
    [SerializeField] public int curBulletRemain;//�c�e
    [SerializeField] public bool isReloading;//�����[�h��
    public bool isTrigger;//�ˌ��{�^���������Ă���
    public bool isFire;//�ˌ���
    private Vector2 direction;//����
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    protected virtual void Start()
    {
        curBulletRemain = MaxBulletNum;//�c�e���[
    }

    private void Update()
    {
        if (isTrigger)//�ˌ��{�^����������Ă��鎞
        {
            Fire();//�ˌ�
            if (!auto) isTrigger = false;//�蓮����̏ꍇ�ˌ��{�^���̃t���O���~�낷
        }
    }

    public virtual void Fire()
    {
        //�e����������Ă��Ȃ���
        //�c�e��0�̂Ƃ�
        //�����[�h���̎�
        //�ˌ����̎�
        //Fire���\�b�h���s��Ȃ�
        if (bullet == null) { Debug.Log("�e���Ȃ�"); return; }
        if (curBulletRemain <= 0) { Debug.Log("�c�e0");return; }
        if (isReloading) { Debug.Log("�����[�h��"); return; }
        if (isFire) { return; }

            curBulletRemain--;//�c�e�������炷
            float rad = angle * Mathf.Deg2Rad;//�p�x�����W�A���ɕϊ�
            //sin,cos�����߂�
            float sin = Mathf.Sin(rad);
            float cos = Mathf.Cos(rad);

            direction = new Vector2(sin, cos);//�p�x�Ƃ���sin,cos����
            var b = Instantiate(bullet, transform.position, Quaternion.identity);//�e�𐶐�
            b.SetVelocity(direction.normalized * speed);//�e�ɑ��x����

            //���˒��̃t���O�𗧂Ă�
            //�w�肵��rate�ԊJ���Ĕ��˒��̃t���O���~�낷
            isFire = true;
            Invoke(nameof(OnFire), rate);
    }


    private void OnFire()
    {
        isFire = false;//���˒��̃t���O���~�낷
    }

    public void Reload()
    {
        if (isReloading) return;//�����[�h���Ȃ炱�̏������s��Ȃ�
        if (curBulletRemain == MaxBulletNum) return;//�e�������^���̎����̏������s��Ȃ�
        Debug.Log("�����[�h��");
        isReloading = true;//�����[�h���t���O�𗧂Ă�
        Invoke(nameof(OnReload), reloadTime);//�����[�h�̃��\�b�h��reloadTime���Ԋu���J���ČĂяo��
    }

    public void OnReload()
    {
        Debug.Log("�����[�h����");
        curBulletRemain = MaxBulletNum;//�c�e���ő�e���ɂ���
        isReloading = false;//�����[�h���I����
    }
}
