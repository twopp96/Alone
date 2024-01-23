using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Gun : Item
{
/*    [SerializeField]
    protected string shotSound;*/

    public GameObject fierPos;
    protected int maxBullet;
    [SerializeField]
    public int curBullet;
    protected float fireRate;
    protected float damage;
    protected float reloadSpeed = 1f;
    protected Player player;
    public float fireSpeed = 10000f;


    public bool isCool = false;
    public bool isEquip;

    public Bullet bul;
    protected Rigidbody bulletRb;


    public TextMeshProUGUI curBulletTxt;
    public Image weaponImage;
    public Sprite image;


    protected virtual void Start()
    {
        
    }



    public virtual void Shoot()
    {

    }

    public virtual void ZoomCamera()
    {

    }

    public virtual void ZoomReturn()
    {

    }

    private void Update()
    {
        if(curBulletTxt != null)
            curBulletTxt.text = curBullet.ToString();
    }

}

// �Ѿ��� ���� ������ �ִ� ���̰�
// ���͸� ����ؼ� �Ѿ��� ������,�ӵ� = ��(this.damage, speed)