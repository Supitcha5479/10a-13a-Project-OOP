using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character
{
    private int damageHit; //��駪��͵��prob �ѹ���ٵ� ����Ẻ���ǡѹ�������˹�ҵ����� ��ͧ�յ�ʹ
    public int DamageHit
    {
        get
        {
            return damageHit;
        }
        set
        {
            damageHit = value;
        }
    }

    private void Start()
    {
        Behaviour();
    }

    public abstract void Behaviour(); //���ѧ������ Abstact -> �á�ç��ҧ ź {} ���; ��ͷ������

}