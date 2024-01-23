using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Animations;
using UnityEngine.SocialPlatforms;

public class Monster_Main : Monster
{
    new float hp;
    public new float Hp
    {
        get { return hp; }
        set
        {
            hp = value;
            if (this.Hp <= 50 && isSafe == true)
            {
                this.Hp = 50;
                barrier.gameObject.SetActive(true);

                Instantiate(monster[monsterArraySize-1], spawnPointBoss[spawnArraySize - 3].position, spawnPointBoss[spawnArraySize - 3].rotation);
                Instantiate(monster[monsterArraySize - 2], spawnPointBoss[spawnArraySize - 3].position, spawnPointBoss[spawnArraySize - 3].rotation);
                Instantiate(monster[monsterArraySize - 3], spawnPointBoss[spawnArraySize - 3].position, spawnPointBoss[spawnArraySize - 3].rotation);
            }
            if (this.Hp <= 0)
            {
                //SoundManager.instance.PlaySE(effectSounds[2]);
                //isDead = true;
                this.Hp = 0;
                StopCoroutine(AttackPattern());
                Die();
            }
            if (hp <= 0)
            {
                hp = 0;

                Die();
            }
        }
    }

    public Spell1 skill1;
    public Spell2 skill2;

    bool isCool;
    bool isSafe;

    float currTime; //�ð� ����

    public Transform[] spawnPointNormal;
    public Transform[] spawnPointBoss;

    public SpawnPoint monsterUse;

    public GameObject[] monster;
    public FireBarrier barrier;

     [SerializeField]
    private string[] effectSounds = new string[3];

    int spawnArraySize = 3;
    int monsterArraySize = 4;
    public int safeDestroy = 3;

    public Slider bossHpBar;
    public GameObject bossHp;

    // Start is called before the first frame update
    private void Awake()
    {
        Hp = 1100;
        //������ �ִϸ����� ������Ʈ�� �Է½�Ŵ!
        ani = gameObject.GetComponent<Animator>();
        //Ÿ��(�÷��̾�)�� ��ġ�� �Է½�Ŵ
        //targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        //������ٵ� ������Ʈ ������: �ӵ� ������
        rb = GetComponent<Rigidbody>();

        skill1 = FindObjectOfType<Spell1>();
        skill2 = FindObjectOfType<Spell2>();

        //col = GetComponent<BoxCollider>();

        barrier = FindObjectOfType<FireBarrier>(true);

        isSafe = true;
    }

    void Start()
    {
        gameObject.SetActive(false);
        barrier.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Bullet bullet))
        {
            Hp -= bullet.Damage;
        }
    }

    public IEnumerator AttackPattern()
    {
        while (true)
        {
            int random = Random.Range(0, 2);

            switch (random)
            {
                case 0:
                    //SoundManager.instance.PlaySE(effectSounds[0]);
                    ani.SetTrigger("attack1");
                    skill1.isTrigger = true;
                    break;
                case 1:
                    //SoundManager.instance.PlaySE(effectSounds[1]);
                    ani.SetTrigger("attack2");
                    skill2.isTrigger = true;
                    break;
            }
            if (isCool == true)
            {
                yield return new WaitForSeconds(1);
                isCool = false;
            }
            yield return new WaitForSeconds(6f);
            if (this.hp <= 0)
            {
                StopCoroutine(AttackPattern());
            }
        }
    }

    public override void Die()
    {
        this.ani.SetTrigger("Death"); //�ִϸ��̼� "Death" ���
        //this.isDead = true; //isDead Ȱ��ȭ

        Destroy(gameObject, 3.0f);
    }

    void Update()
    {
        //jaw�� ��� �Լ� �����غ���

        currTime += Time.deltaTime; //�ð����� �ð��帣�� 
        if (currTime > 20) // �ð������� 10�ʺ��� Ŭ�� 
        {
            Instantiate(monster[monsterArraySize-4], spawnPointNormal[spawnArraySize - 3].position, spawnPointNormal[spawnArraySize - 3].rotation); // ���͹迭 [1] ���ִ� ���� ����
            Instantiate(monster[monsterArraySize-4], spawnPointNormal[spawnArraySize - 2].position, spawnPointNormal[spawnArraySize - 2].rotation); // ���͹迭 [1] ���ִ� ���� ����
            Instantiate(monster[monsterArraySize-4], spawnPointNormal[spawnArraySize - 1].position, spawnPointNormal[spawnArraySize - 1].rotation); // ���͹迭 [1] ���ִ� ���� ����

            Debug.Log("��ȯ����");
            currTime = 0; //�ð� 0�ʷ� �ٽõ��ư��� �ݺ�.
        }
        
        if (isCool == false)
        {
            isCool = true;
        }

        if (safeDestroy == 0)
        {
            isSafe = false;
            barrier.gameObject.SetActive(false);
        }
        //bossHpBar.value = hp / maxHp;
    }
}