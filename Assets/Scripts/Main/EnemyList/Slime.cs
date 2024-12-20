using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy, IShootable
{
    float attackRange;
    public float AttackRange { get { return attackRange; } set { attackRange = value; } }

    public Player player;

    [field: SerializeField] //��ҡ����Unity ��Ẻ���Ѻ ����� public ����¹������� [SerializeField] ��
    GameObject bullet;
    public GameObject Bullet { get { return bullet; } set { bullet = value; } }


    [field: SerializeField] //[SerializeField] ������Ѻ private ��ҹ��
    Transform bulletSpawnPoint;
    public Transform BulletSpawnPoint { get { return bulletSpawnPoint; } set { bulletSpawnPoint = value; } } // ��ͺ�͵��Ẻ�����

    [field: SerializeField]
    public float ReloadTime { get; set; } // ��ͺ�͵��Ẻ��� ����� �ѹ����ͧ [field: SerializeField] 
    [field: SerializeField]
    public float WaitTime { get; set; }


    private void FixedUpdate() //�� Start ����١�ͧ�������ʴ��� ��������������١
    {
        WaitTime += Time.fixedDeltaTime;
        Behaviour();
    }

    public override void Behaviour() //��ͧ������ Enemy ��ҡ����������Դ �ç abstract �� override ᷹
    {
        Vector2 direction = player.transform.position - transform.position;
        //if (distance.magnitude <= attackRange)
        float distance = direction.magnitude;
        {
            Shoot();
        }
    }

    public void Shoot()
    {

        if (WaitTime >= ReloadTime)
        {
            //anim.SetTrigger("Shoot");

            GameObject obj = Instantiate(Bullet, BulletSpawnPoint.position, Quaternion.identity);
            Acid acid = obj.GetComponent<Acid>(); // obj ��ͻʤ�Ի�ͧ���������¹
            acid.Init(20, this); //this ��͵��Slime
            WaitTime = 0;

        }
    }
    void Awake()
    {
        WaitTime = 0f;
        ReloadTime = 5f;
        AttackRange = 6;
        DamageHit = 30;

    }
    void Start()
    {
        Init(100); //���ʹ�͹
        healthBar.SetMaxHealth(100);
        player = GameObject.FindObjectOfType<Player>();

    }
}
