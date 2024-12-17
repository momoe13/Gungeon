using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadBar : MonoBehaviour
{
    [Header("�����_")][SerializeField] GameObject movePoint;
    [Header("�n�_")][SerializeField] GameObject firstPoint;
    [Header("�I�_")][SerializeField] GameObject lastPoint;

    [HideInInspector]public float reloadTime;//�����[�h����
    [HideInInspector]public bool isReload = false;

    private void Start()
    {
        movePoint.transform.position = firstPoint.transform.position;//�����_�������ʒu�ɃZ�b�g
    }
    void Update()
    {
        if(!isReload) return;

        float dis = lastPoint.transform.position.x - firstPoint.transform.position.x;//�n�_�ƏI�_�̋��������߂�
        float spe = dis / reloadTime;//���������ԂŊ����đ��������߂�
        movePoint.transform.Translate(spe * Time.deltaTime, 0, 0);//�����_�����߂����x�œ�����

        if (movePoint.transform.position.x >= lastPoint.transform.position.x)//�����_���I�_�܂ōs�����Ƃ�
        {
            movePoint.transform.position = firstPoint.transform.position;//�����_�������ʒu�ɖ߂�
            isReload = false;//�����[�h���I����
        }
    }

}
