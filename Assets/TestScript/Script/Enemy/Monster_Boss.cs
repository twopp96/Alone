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

    //스타트 함수는 상속이 불가능!
    void Start()
    {
        sMachine = new StateMachine();
        sMachine.own = this;


        sMachine.AddState("Move", new MoveState());
        sMachine.AddState("Chase", new ChaseState());
        sMachine.AddState("Attack", new AttackState());

        sMachine.SetState("Move");


        //몬스터의 애니매이터 컴포넌트를 입력시킴!
        ani = gameObject.GetComponent<Animator>();

        //타겟(플레이어)의 위치를 입력시킴
        //targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;

        move = GetComponent<NavMeshAgent>();

        //리지드바디 컴포넌트 가져옴: 속도 고정용
        rb = GetComponent<Rigidbody>();

        portal = FindObjectOfType<Portal>(true);

        spwanPoint = FindObjectOfType<SpawnPoint>();

        boss=FindObjectOfType<Monster_Main>();

        shield.SetActive(true);
    }

    public override void Die()
    {
        //this.isDead = true; //isDead 활성화
        this.DropItem(); //DropItem 함수 실행
        //this.onDie(); //onDie이벤트 활성화
        move.SetDestination(move.transform.position);
        this.ani.SetTrigger("Death"); //애니메이션 "Death" 출력
       if(spwanPoint.open==true)
        {
            boss.safeDestroy--;
        }
        spwanPoint.goToBoss++;

        if(spwanPoint.goToBoss==3)
        {
            spwanPoint.open=true;

            Debug.Log("차원문");
            /*portal.transform.position = targetPlayer.transform.position;
            portal.transform.position += (targetPlayer.transform.forward * 5f);
            portal.transform.position += (targetPlayer.transform.up * 1.5f);*/
            shield.SetActive(false);
            portal.gameObject.SetActive(true);
        }
        Destroy(gameObject, 3.0f); //게임오브젝트 3초후 파괴.
    }

    public override void DropItem()
    {
        //var 변수는 무조건 지역변수로만 선언해야하고 초기화작업을 바로 해야 사용 가능
        var itemGo = Instantiate<GameObject>(this.boxPrefab); // Instantiate 함수는 플레이중 게임오브젝트 생성한다.
        itemGo.transform.position = this.gameObject.transform.position; //itemGo의 위치는 생성된 아이템프리팹 위치.
        itemGo.SetActive(true); //itemgo를 비활성화 (object.SetActive(false) << 오브젝트를 비활성화시킴.)
    }

    void Update()
    {
        sMachine.Update();
        //bossHpBar.value = hp / maxHp;
    }
}
