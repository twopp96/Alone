using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public interface IStateMachine
{
    void SetState(string name);
    Monster GetOwn();
}
public class State
{
    public IStateMachine state; //IStateMachine의 SetState상태를 사용하기 위해 has-a관계로 가지고 있음

    public virtual void Init(IStateMachine state)
    {
        this.state = state;
    }
    public virtual void OnEnter() { }
    public virtual void OnExit() { }
    public virtual void OnUpdate() { }

}
public class MonsterState : State
{
    public Vector3 targetPos;
    public Monster monster;

    public override void Init(IStateMachine state)
    {
        base.Init(state);
        monster = state.GetOwn();
    }

    public void FreezeRotation()
    {
        monster.rb.angularVelocity = Vector3.zero;
        monster.rb.velocity = Vector3.zero;
    }
}
public class MoveState : MonsterState
{
    float maxMoveRange = 20f;

    public override void OnEnter()
    {
        monster.targetCol = null;
        targetPos = monster.transform.position;
    }

    public override void OnUpdate()
    {
        FreezeRotation();

        Collider[] cols = Physics.OverlapSphere(monster.transform.position, maxMoveRange, 1 << LayerMask.NameToLayer("Player"));
        if (cols.Length > 0)
        {
            foreach (Collider col in cols)
            {
                if (col.TryGetComponent(out Player player))
                {
                    monster.targetCol = col;
                    state.SetState("Chase");
                    return;
                }
                else if (col.TryGetComponent(out DroneMove drone))
                {
                    monster.targetCol = col;
                    state.SetState("Chase");
                    return;
                }
            }
        }
        //타겟을 못찾았으면 원래 위치에 대기
        else monster.move.SetDestination(targetPos);
    }
}
public class ChaseState : MonsterState
{
    float attackRange = 5f;
    float missingDistance = 10f;

    public override void OnEnter()
    {

    }
    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {
        FreezeRotation();
        targetPos = monster.transform.position;

        Vector3 target = monster.targetCol.transform.position;
        monster.move.SetDestination(target);
        Debug.Log((target - monster.transform.position).magnitude);

        if ((target - targetPos).magnitude <= attackRange)
        {
            state.SetState("Attack");
        }
        if ((target - targetPos).magnitude >= missingDistance)
        {
            state.SetState("Move");
        }
    }
}
public interface IAnimationable
{
    public void SetAni();
}
public class AttackState : MonsterState
{

    public override void OnEnter()
    {

    }

    public override void OnUpdate()
    {
        targetPos = monster.transform.position;

        Vector3 target = monster.targetCol.transform.position;
        Vector3 dir = (targetPos - target).normalized;

        Debug.DrawRay(targetPos, monster.transform.forward, Color.red,3f);

        monster.move.SetDestination(target);
        RaycastHit hit;
        if (Physics.Raycast(targetPos, monster.transform.forward, out hit, 3f))
        {
            Debug.Log("Lay닿음");
            int pattern = Random.Range(0, monster.atkPatternCount);
            monster.ani.SetInteger("Int",pattern);
        }
        if ((targetPos - target).magnitude >= 3f)
        {
            monster.ani.SetInteger("Int", 99);
            state.SetState("Move");
        }
    }
}


public class StateMachine : IStateMachine
{
    public Monster own;
    public State curState;

    Dictionary<string, State> stateDic;

    public StateMachine()
    {
        stateDic = new Dictionary<string, State>();
    }
    public void AddState(string name, State state)
    {
        if (stateDic.ContainsKey(name))
            return;
        Debug.Log(name);
        state.Init(this);
        stateDic.Add(name, state);
    }

    public Monster GetOwn()
    {
        return own;
    }

    public void SetState(string name)
    {
        if (stateDic.ContainsKey(name))
        {
            if (curState != null)
            {
                curState.OnExit();
            }
            curState = stateDic[name];
            curState.OnEnter();
        }
    }

    public void Update()
    {
        curState.OnUpdate();
    }
}

public class Monster : MonoBehaviour
{
    public int atkPatternCount;
    protected float hp;
    public float Hp
    {
        get { return hp; }
        set
        {
            hp = value;
            if (hp <= 0)
            {
                hp = 0;
                Die();
            }
        }
    }
    private float atk;
    public float Atk { get => atk; }

    public NavMeshAgent move;
    public GameObject boxPrefab;

    //타겟 추적시 위치 설정을 위한 콜라이더
    //상태머신을 통해 null 혹은 타겟을 설정해줌
    public Collider targetCol;
    public Collider attackCol;

    protected StateMachine sMachine;
    public Animator ani;
    public Rigidbody rb;


    void Start()
    {
        Hp = 100;
        atkPatternCount = 1;

        move = GetComponent<NavMeshAgent>();
        rb= GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();

        sMachine = new StateMachine();
        sMachine.own = this;

        sMachine.AddState("Move", new MoveState());
        sMachine.AddState("Chase", new ChaseState());
        sMachine.AddState("Attack", new AttackState());

        //처음에는 이동 상태로!
        sMachine.SetState("Move");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bullet bullet))
        {
            Hp -= bullet.Damage;
        }
    }


  /*  private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 20f);
        Gizmos.color = Color.red;
    }*/

    // Update is called once per frame
    void Update()
    {
        sMachine.Update();
    }

    public virtual void Die()
    {
        int random;
        random = Random.Range(0, 5);
        Debug.Log("아이템" + random);

        move.SetDestination(move.transform.position);
        ani.SetTrigger("Death"); //애니메이션 "Death" 출력
        if (random < 1)
        {
           DropItem(); //DropItem 함수 실행
        }
        //gameObject.SetActive(false);
        Destroy(gameObject, 2.5f); //게임오브젝트 3초후 파괴.
    }
    public virtual void DropItem()
    {
        GameObject itemGo = Instantiate(boxPrefab); // Instantiate 함수는 플레이중 게임오브젝트 생성한다.
        itemGo.transform.position = gameObject.transform.position; //itemGo의 위치는 생성된 아이템프리팹 위치.
    }

    public void ColliderOff(){attackCol.enabled=false;}
    public void ColliderOn() {attackCol.enabled=true;}
}
