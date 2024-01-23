using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using UnityEngine.AI;
using JetBrains.Annotations;
using Random = UnityEngine.Random;

public class Monster_Boss : Monster
{
    SpawnPoint spwanPoint;
    Monster_Main boss;
    public Portal portal;
    public Player player;

    public GameObject shield;
    public Slider bossHpBar;
    public GameObject bossHp;

    //��ŸƮ �Լ��� ����� �Ұ���!
    void Start()
    {
        sMachine = new StateMachine();
        sMachine.own = this;


        sMachine.AddState("Move", new MoveState());
        sMachine.AddState("Chase", new ChaseState());
        sMachine.AddState("Attack", new AttackState());

        sMachine.SetState("Move");


        //������ �ִϸ����� ������Ʈ�� �Է½�Ŵ!
        ani = gameObject.GetComponent<Animator>();

        //Ÿ��(�÷��̾�)�� ��ġ�� �Է½�Ŵ
        //targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;

        move = GetComponent<NavMeshAgent>();

        //������ٵ� ������Ʈ ������: �ӵ� ������
        rb = GetComponent<Rigidbody>();

        portal = FindObjectOfType<Portal>(true);

        spwanPoint = FindObjectOfType<SpawnPoint>();

        boss=FindObjectOfType<Monster_Main>();

        shield.SetActive(true);
    }

    public override void Die()
    {
        //this.isDead = true; //isDead Ȱ��ȭ
        this.DropItem(); //DropItem �Լ� ����
        //this.onDie(); //onDie�̺�Ʈ Ȱ��ȭ
        move.SetDestination(move.transform.position);
        this.ani.SetTrigger("Death"); //�ִϸ��̼� "Death" ���
       if(spwanPoint.open==true)
        {
            boss.safeDestroy--;
        }
        spwanPoint.goToBoss++;

        if(spwanPoint.goToBoss==3)
        {
            spwanPoint.open=true;

            Debug.Log("������");
            /*portal.transform.position = targetPlayer.transform.position;
            portal.transform.position += (targetPlayer.transform.forward * 5f);
            portal.transform.position += (targetPlayer.transform.up * 1.5f);*/
            shield.SetActive(false);
            portal.gameObject.SetActive(true);
        }
        Destroy(gameObject, 3.0f); //���ӿ�����Ʈ 3���� �ı�.
    }

    public override void DropItem()
    {
        //var ������ ������ ���������θ� �����ؾ��ϰ� �ʱ�ȭ�۾��� �ٷ� �ؾ� ��� ����
        var itemGo = Instantiate<GameObject>(this.boxPrefab); // Instantiate �Լ��� �÷����� ���ӿ�����Ʈ �����Ѵ�.
        itemGo.transform.position = this.gameObject.transform.position; //itemGo�� ��ġ�� ������ ������������ ��ġ.
        itemGo.SetActive(true); //itemgo�� ��Ȱ��ȭ (object.SetActive(false) << ������Ʈ�� ��Ȱ��ȭ��Ŵ.)
    }

    void Update()
    {
        sMachine.Update();
        //bossHpBar.value = hp / maxHp;
    }
}
