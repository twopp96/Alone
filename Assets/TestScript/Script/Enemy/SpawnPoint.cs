using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject[] monster; //���� �������� �����ϱ� ���� �뵵(����Ƽ���� ������ ���� ����)
    int arraySize = 3;             //�Ϲݸ� �迭 3�� �ν���Ʈ���� Ȱ��
    int monsterCount = 10;        //��ȯ�� ���� �� ����

    public Transform[] spawnPoint_MonsterCreature1_LP;      //��ȯ�� ���� ��ǥ�� �迭�� �� ����(����Ƽ����)
    public Transform[] spawnPoint_FishMan;      //��ȯ�� ���� ��ǥ�� �迭�� ���� ����(����Ƽ����)
    public Transform[] spawnPoint_Medusa;      //��ȯ�� ���� ��ǥ�� �迭�� ���� ����(����Ƽ����)

    //������ ���� �� Ʈ����ī��Ʈ: �߰����� ���������� goToBoss++; 3�Ǹ� bool open�� ����
    public int goToBoss;
    //goToBoss�� 3�� �Ǹ� ������ �� �� �ִ� ����ġ
    public bool open;

    void Start()
    {
        //�ϴ� �������� ���� ��ȯ�ϰ� ��� ������
        StartCoroutine(Summon());
        goToBoss = 0;
        open = false;

    }

    IEnumerator Summon()
    {
        yield return new WaitForSeconds(1);     //������ �� 1�� �ڿ� �����ϰ� ����

        while (monsterCount > 0)
        {
            monsterCount--;
            RandomSpawn(monsterCount);
       
        }
    }

    void RandomSpawn(int num)
    {
        Instantiate(monster[arraySize - 3], spawnPoint_MonsterCreature1_LP[monsterCount].position, spawnPoint_MonsterCreature1_LP[monsterCount].rotation);
        Instantiate(monster[arraySize - 2], spawnPoint_FishMan[monsterCount].position, spawnPoint_FishMan[monsterCount].rotation);
        Instantiate(monster[arraySize - 1], spawnPoint_Medusa[monsterCount].position, spawnPoint_Medusa[monsterCount].rotation);
    }




}